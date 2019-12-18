using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;

namespace EasyCore.Minio.Config
{
    public class MinioConfig : IOptions<MinioConfig>
    {
        /// <summary>
        /// Minio服务端地址
        /// </summary>
        public string Endpoint { get; set; }
        /// <summary>
        /// AccessKey
        /// </summary>
        public string AccessKey { get; set; }
        /// <summary>
        /// SecretKey
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// Region
        /// </summary>
        public string Region { get; set; } = "";
        /// <summary>
        /// SessionToken
        /// </summary>
        public string SessionToken { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public MinioConfig Value => this;
    }
}
