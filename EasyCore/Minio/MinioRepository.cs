using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Minio;

namespace EasyCore.Minio
{
    public class MinioRepository : MinioClient, IMinioRepository
    {
        public MinioRepository(string endpoint, string accessKey = "", string secretKey = "", string region = "", string sessionToken = "") : base(endpoint, accessKey, secretKey, region, sessionToken)
        {
        }
    }
}
