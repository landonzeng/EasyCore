using EasyCore.Entity.Enum;
using EasyCore.Entity.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Net;

namespace EasyCore.OtherExtensions.ExceptionHelper
{
    /// <summary>
    /// 全局报错拦截
    /// </summary>
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILoggerFactory _loggerFactory;//日志工厂

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="loggerFactory"></param>
        /// <param name="env"></param>
        public HttpGlobalExceptionFilter(ILoggerFactory loggerFactory, IHostingEnvironment env)
        {
            _loggerFactory = loggerFactory;
        }
        /// <summary>
        /// 拦截器生命周期
        /// </summary>
        /// <param name="context">获取上下文</param>
        public void OnException(ExceptionContext context)
        {
            var logger = _loggerFactory.CreateLogger(context.Exception.TargetSite?.ReflectedType ?? typeof(ExceptionContext));
            logger.LogError(new EventId(context.Exception.HResult),
            context.Exception,
            context.Exception.Message);
            var json = new ResponseContent(data: "系统错误,请联系管理员", msg: "failed", code: ResposeCode.Error);
            if (context.Exception.TargetSite.Name == "NotNull" || context.Exception.TargetSite.Name == "CheckCondition" || context.Exception.TargetSite.Name == "NotEmpty")
            {
                json.Message = context.Exception.Message;
                json.Code = (int)ResposeCode.Failed;
            }
            else
            {
                json.Message = context.Exception.Message;
                json.Data = context.Exception.StackTrace;
            }
            context.Result = new ApplicationErrorResult(json);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            context.ExceptionHandled = true;
        }
        /// <summary>
        /// 错误返回
        /// </summary>
        public class ApplicationErrorResult : ObjectResult
        {
            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="value"></param>
            public ApplicationErrorResult(object value) : base(value)
            {
                StatusCode = (int)HttpStatusCode.OK;
            }
        }        
    }
}
