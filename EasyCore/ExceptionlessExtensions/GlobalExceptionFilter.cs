using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EasyCore.Entity.Enum;
using EasyCore.Entity.Response;
using EasyCore.Utilities;
using Exceptionless;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RestSharp.Extensions;

namespace EasyCore.ExceptionlessExtensions
{
    /// <summary>
    /// 定义全局过滤器
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public string RequestParametersString { get; set; }

        private readonly ILoggerHelper _loggerHelper;

        //构造函数注入ILoggerHelper
        public GlobalExceptionFilter(ILoggerHelper loggerHelper)
        {
            _loggerHelper = loggerHelper;
        }

        public void OnExcuting(ActionExecutingContext actionExecutingContext)
        {
            RequestParametersString = actionExecutingContext.ActionArguments.ToJson();
        }

        public void OnException(ExceptionContext filterContext)
        {
            //_loggerHelper.Error(filterContext.Exception.TargetSite.GetType().FullName, filterContext.Exception.ToString(), MpcKeys.GlobalExceptionCommonTags, filterContext.Exception.GetType().FullName);
            //_loggerHelper.Error(filterContext.Exception.TargetSite.GetType().FullName, filterContext.Exception.ToString(), "global_exception_common_tags", filterContext.Exception.GetType().FullName);

            ////获取表单参数

            filterContext.Exception.ToExceptionless().SetMessage(filterContext.Exception.Message).Submit();

            //_loggerHelper.Error(source: filterContext.HttpContext.Request.Path+ " || " + filterContext.HttpContext.Request.Method, filterContext.Exception.ToString(), "global_exception_common_tags", filterContext.Exception.GetType().FullName);
            var result = new ResponseContent()
            {
                Data = filterContext.Exception.ToString(),
                Message = "系统异常，请联系管理员",
                Code = (int)ResposeCode.Error
            };
            filterContext.Result = new ObjectResult(result);
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            filterContext.ExceptionHandled = true;
        }
    }
}