using System;
using System.Collections.Generic;
using System.Text;
using EasyCore.Entity.Enum;

namespace EasyCore.Entity.Response
{
    /// <summary>
    /// 返回文本定义
    /// </summary>
    public class ResponseContent
    {
        public ResponseContent()
        {
        }

        /// <summary>
        /// 构造函数 默认msg=success code=0
        /// </summary>
        /// <param name="data">返回数据</param>
        /// <param name="msg">返回的消息</param>
        /// <param name="code">返回码</param>
        public ResponseContent(object data, string msg = "success", ResposeCode code = ResposeCode.Success)
        {
            Data = data;
            Message = msg;
            Code = (int)code;
        }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 返回码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }
    }
}
