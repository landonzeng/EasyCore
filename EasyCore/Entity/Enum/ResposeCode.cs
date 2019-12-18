using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EasyCore.Entity.Enum
{
    /// <summary>
    /// 返回代码
    /// </summary>
    public enum ResposeCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 200,
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Failed = 400,
        /// <summary>
        /// 异常
        /// </summary>
        [Description("异常")]
        Error = 500,
        /// <summary>
        /// 无权限
        /// </summary>
        [Description("权限不足")]
        NoAuth = 401,
        /// <summary>
        /// 无内容
        /// </summary>
        [Description("无内容")]
        NoContent = 204
    }
}
