using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCore.OtherExtensions.Authorization
{
    /// <summary>
    /// 身份类型
    /// </summary>
    public class ClaimsType
    {
        /// <summary>
        /// 实名
        /// </summary>
        public const string RealName = "realname";
        /// <summary>
        /// 公司id
        /// </summary>
        public const string CompanyId = "companyid";
        /// <summary>
        /// 公司代号
        /// </summary>
        public const string CompanyCode = "companycode";
        /// <summary>
        /// 部门id
        /// </summary>
        public const string DepartmentId = "departmentid";
        /// <summary>
        /// 用户id
        /// </summary>
        public const string Subject = "sub";
        /// <summary>
        /// email
        /// </summary>
        public const string Email = "email";
        /// <summary>
        /// 账号
        /// </summary>
        public const string Account = "account";
        /// <summary>
        /// 是否为超级管理员
        /// </summary>
        public const string IsAdmin = "isadmin";
        /// <summary>
        /// 是否为系统管理员
        /// </summary>
        public const string IsSysManager = "issysmanager";
        /// <summary>
        /// 
        /// </summary>
        public const string Name = "name";
        /// <summary>
        /// 角色id
        /// </summary>
        public const string Role = "role";
        /// <summary>
        /// 所属客户端
        /// </summary>
        public const string Client = "client";
    }
}
