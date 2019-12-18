using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingTalk.Api;
using DingTalk.Api.Request;
using DingTalk.Api.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.IServices;
using WebApi.Module;
using EasyCore.Utilities;
using static DingTalk.Api.Response.OapiRoleSimplelistResponse;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IBaseUserServices _baseUserServices;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBaseUserServices baseUserServices)
        {
            _logger = logger;
            _baseUserServices = baseUserServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var data= await _baseUserServices.GetList();
            //var data = await _baseUserServices.UnitOfWork.GetRepository<LR_Base_Company>().Select.ToListAsync();
            //return Ok(data);


            #region 获取公司所有角色
            var db_userList = await _baseUserServices.UnitOfWork.GetGuidRepository<V_EmployeeToDingTalk>().Select.Where(it => it.Enabled == 1).ToListAsync();
            var db_role = await _baseUserServices.UnitOfWork.GetGuidRepository<V_EmployeeToDingTalk>().Select.Where(it => it.Enabled == 1).GroupBy(it => it.PositionName).ToListAsync(a => a.Key);
            #endregion


            #region 获取钉钉Token
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/gettoken");
            OapiGettokenRequest request = new OapiGettokenRequest();
            request.Appkey = "dingzaylvubm9xhoeijk";
            request.Appsecret = "eJaM-HBxG74ABJhnIYPNMVXNLZQqHSxkgKshtcHFO1pBybjpmbTZwqitgDnPtncu";
            request.SetHttpMethod("GET");
            OapiGettokenResponse response = client.Execute(request);
            #endregion

            #region 获取角色列表
            client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/list");
            var requestRole = new OapiRoleListRequest();
            requestRole.Offset = 0L;
            requestRole.Size = 200L;

            OapiRoleListResponse responseRoleList = client.Execute(requestRole, response.AccessToken);
            #endregion

            List<OapiRoleAddroleResponse> result = new List<OapiRoleAddroleResponse>();
            var dd_roleList = responseRoleList.Result.List.Where(it => it.Name == "职位").FirstOrDefault();

            #region 获取职位角色下所有角色列表，然后删除其中的所有员工
            //foreach (var item in dd_roleList.Roles)
            //{
            //    client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/deleterole");
            //    OapiRoleDeleteroleRequest delete_request = new OapiRoleDeleteroleRequest();
            //    delete_request.RoleId = item.Id;

            //    OapiRoleDeleteroleResponse del_response = client.Execute(delete_request, response.AccessToken);
            //    if (del_response.Errcode != 0)
            //    {
            //        #region 获取该角色下的用户
            //        client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/simplelist");
            //        OapiRoleSimplelistRequest request_roleUser = new OapiRoleSimplelistRequest();
            //        request_roleUser.RoleId = item.Id;
            //        request_roleUser.Offset = 0;
            //        request_roleUser.Size = 200;

            //        OapiRoleSimplelistResponse response_roleUser = client.Execute(request_roleUser, response.AccessToken);

            //        foreach (var userList in response_roleUser.Result.List)
            //        {
            //            client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/removerolesforemps");
            //            OapiRoleRemoverolesforempsRequest request_deleteUser = new OapiRoleRemoverolesforempsRequest();

            //            request_deleteUser.RoleIds = item.Id.ToString();
            //            request_deleteUser.UserIds = userList.Userid;

            //            OapiRoleRemoverolesforempsResponse response_delUser = client.Execute(request_deleteUser, response.AccessToken);
            //            if (response_delUser.Errcode != 0)
            //            {
            //                Console.WriteLine("\n" + response_delUser.Errmsg + "\n");
            //            }
            //        }
            //        client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/deleterole");
            //        delete_request = new OapiRoleDeleteroleRequest();
            //        delete_request.RoleId = item.Id;

            //        del_response = client.Execute(delete_request, response.AccessToken);
            //        if (del_response.Errcode != 0)
            //        {
            //            Console.WriteLine("\n" + del_response.Errmsg + "\n");
            //        }
            //        else
            //        {
            //            Console.WriteLine("\n角色下有人员，但已删除成功！\n");
            //        }

            //        #endregion
            //    }
            //}
            #endregion


            var dd_roles = dd_roleList.Roles?.Select(it => it.Name).ToList();
            var strlist = dd_roles;
            if (dd_roles != null)
            {
                strlist = db_role.Except(dd_roles).ToList();
            }

            #region 获取角色下的所有用户
            client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/simplelist");
            List<EmpSimpleDomain> simpleDomainsList = new List<EmpSimpleDomain>();
            if (dd_roleList.Roles != null)
            {
                foreach (var item in dd_roleList.Roles)
                {
                    GetSimplelistResponse(simpleDomainsList, client, response, item);
                }
            }
            #endregion

            #region 过滤掉加入到钉钉的用户
            // 不包含
            //var query4 = list2s.Where(s => list1.All(t => !s.name.Contains(t))).ToList();
            string userListJson = db_userList.ToJson();
            List<V_EmployeeToDingTalk> userList = userListJson.ToObject<List<V_EmployeeToDingTalk>>();
            var roleList = userList.GroupBy(it => it.PositionName).ToList();


            List<V_EmployeeToDingTalk> UpdateUserList = new List<V_EmployeeToDingTalk>();
            List<V_EmployeeToDingTalk> AddUserList = new List<V_EmployeeToDingTalk>();


            //钉钉加入到职务角色下的所有员工
            var ddroleList = simpleDomainsList.GroupBy(it => it.RoleName).ToList();

            var res = ddroleList.Select(r =>
            {
                var dbusers = db_userList.Where(u => u.PositionName == r.Key).Select(ur => ur.UserId);
                var ddUsers = r.SelectMany(ru => ru.List).Select(rl => rl.Userid);
                return new
                {
                    RoleId = r.First().RoleId,
                    RoleName = r.Key,
                    InserUser = dbusers.Except(ddUsers),
                    DeleteUser = ddUsers.Except(dbusers)
                };
            });


            string userStr = "";
            int pageSize = 20;
            foreach (var item in res)
            {
                var userListCount = item.InserUser.Count();
                var updateListCount = item.DeleteUser.Count();

                if (userListCount > 0 || updateListCount > 0)
                {
                    if (userListCount > 0)
                    {
                        var uList = new List<string>();
                        if (userListCount > pageSize)
                        {

                            int pageNum = ((userListCount / pageSize) + (userListCount % pageSize > 0 ? 1 : 0));
                            for (int i = 0; i < pageNum; i++)
                            {
                                //Skip是起始数据,表示从第n+1条数据开始.（此处pageNum应从0开始）
                                //pageNum：页数、=0是第一页,pageSize：一页多少条
                                uList = item.InserUser.OrderBy(it => it).Skip(i * pageSize).Take(pageSize).Select(it => it).ToList();
                                userStr = string.Join(",", uList.ToArray());

                                client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/addrolesforemps");
                                OapiRoleAddrolesforempsRequest addUserRoleRequest = new OapiRoleAddrolesforempsRequest();
                                addUserRoleRequest.RoleIds = item.RoleId.ToString();
                                addUserRoleRequest.UserIds = userStr;
                                OapiRoleAddrolesforempsResponse resp = client.Execute(addUserRoleRequest, response.AccessToken);
                                if (resp.ErrCode != "0")
                                {
                                    Console.WriteLine("\n" + resp.ErrMsg + "\n");
                                }
                            }

                        }
                        else
                        {
                            uList = item.InserUser.OrderBy(it => it).Select(it => it).ToList();
                            userStr = string.Join(",", uList.ToArray());

                            client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/addrolesforemps");
                            OapiRoleAddrolesforempsRequest addUserRoleRequest = new OapiRoleAddrolesforempsRequest();
                            addUserRoleRequest.RoleIds = item.RoleId.ToString();
                            addUserRoleRequest.UserIds = userStr;
                            OapiRoleAddrolesforempsResponse resp = client.Execute(addUserRoleRequest, response.AccessToken);
                            if (resp.ErrCode != "0")
                            {
                                Console.WriteLine("\n" + resp.ErrMsg + "\n");
                            }
                        }
                    }
                    if (updateListCount > 0)
                    {
                        ;
                    }
                }
            }





            //foreach (var item in ddroleList)
            //{
            //    var i = item.FirstOrDefault();


            //    foreach (var value in i.List)
            //    {
            //        UpdateUserList.AddRange(db_userList.Where(it => (it.PositionName != i.RoleName && it.UserId == value.Userid)).ToList());
            //        userList = userList.Where(it => !(it.PositionName == i.RoleName && it.UserId == value.Userid)).ToList();
            //        userList = userList.Where(it => !UpdateUserList.Select(u => u.UserId).Contains(it.UserId)).ToList();
            //    }
            //}




            #endregion

            #region 在职位角色组下创建角色
            //foreach (var item in strlist)
            //{
            //    client = new DefaultDingTalkClient("https://oapi.dingtalk.com/role/add_role");
            //    OapiRoleAddroleRequest req = new OapiRoleAddroleRequest();
            //    req.RoleName = item;
            //    req.GroupId = dd_roleList.GroupId;
            //    OapiRoleAddroleResponse rsp = client.Execute(req, response.AccessToken);
            //    result.Add(rsp);
            //}
            #endregion

            //string userStr = "";
            //int pageSize = 100;
            //foreach (var item in dd_roleList.Roles)
            //{
            //    var userListCount = db_userList.Where(it => it.PositionName == item.Name).Count();
            //    var userList = new List<string>();
            //    if (userListCount > pageSize)
            //    {

            //        int pageNum = ((userListCount / pageSize) + (userListCount % pageSize > 0 ? 1 : 0));
            //        for (int i = 0; i < pageNum; i++)
            //        {
            //            //Skip是起始数据,表示从第n+1条数据开始.（此处pageNum应从0开始）
            //            //pageNum：页数、=0是第一页,pageSize：一页多少条
            //            userList = db_userList.Where(it => it.PositionName == item.Name).OrderBy(it => it.UserId).Skip(i * pageSize).Take(pageSize).Select(it => it.UserId).ToList();
            //            userStr = string.Join(",", userList.ToArray());

            //            client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/addrolesforemps");
            //            OapiRoleAddrolesforempsRequest addUserRoleRequest = new OapiRoleAddrolesforempsRequest();
            //            addUserRoleRequest.RoleIds = item.Id.ToString();
            //            addUserRoleRequest.UserIds = userStr;
            //            OapiRoleAddrolesforempsResponse resp = client.Execute(addUserRoleRequest, response.AccessToken);
            //        }

            //    }
            //    else
            //    {
            //        userList = db_userList.Where(it => it.PositionName == item.Name).OrderBy(it => it.UserId).Select(it => it.UserId).ToList();
            //        userStr = string.Join(",", userList.ToArray());

            //        client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/addrolesforemps");
            //        OapiRoleAddrolesforempsRequest addUserRoleRequest = new OapiRoleAddrolesforempsRequest();
            //        addUserRoleRequest.RoleIds = item.Id.ToString();
            //        addUserRoleRequest.UserIds = userStr;
            //        OapiRoleAddrolesforempsResponse resp = client.Execute(addUserRoleRequest, response.AccessToken);
            //    }
            //}



            #region 根据角色ID删除角色
            //client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/deleterole");
            //OapiRoleDeleteroleRequest request_del = new OapiRoleDeleteroleRequest();
            //request_del.RoleId = postId.Roles[0].Id;

            //OapiRoleDeleteroleResponse res = client.Execute(request_del, response.AccessToken);
            #endregion

            return Ok("成功！");
        }

        private static List<EmpSimpleDomain> GetSimplelistResponse(List<EmpSimpleDomain> simpleList, IDingTalkClient client, OapiGettokenResponse response, OapiRoleListResponse.OpenRoleDomain item, long Offset = 0, long Size = 200)
        {
            OapiRoleSimplelistRequest reqSimplelist = new OapiRoleSimplelistRequest();
            reqSimplelist.RoleId = item.Id;
            reqSimplelist.Offset = Offset;
            reqSimplelist.Size = Size;

            OapiRoleSimplelistResponse respSimplelist = client.Execute(reqSimplelist, response.AccessToken);
            if (respSimplelist.Result.List != null && respSimplelist.Result.List.Count > 0)
            {
                EmpSimpleDomain emp = new EmpSimpleDomain() { List = respSimplelist.Result.List, RoleId = item.Id, RoleName = item.Name };

                simpleList.Add(emp);
            }

            if (respSimplelist.Result.HasMore == true)
            {

                simpleList.AddRange(GetSimplelistResponse(simpleList, client, response, item, respSimplelist.Result.NextCursor));
            }

            return simpleList;
        }

        public class EmpSimpleDomain : PageVoDomain
        {
            public string RoleName { get; set; }
            public long RoleId { get; set; }
        }
    }
}
