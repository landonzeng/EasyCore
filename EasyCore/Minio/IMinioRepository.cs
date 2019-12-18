using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Minio;

namespace EasyCore.Minio
{
    public interface IMinioRepository: IBucketOperations,IObjectOperations
    {
        ///// <summary>
        ///// 创建桶
        ///// </summary>
        ///// <param name="bucketName"></param>
        ///// <param name="location"></param>
        ///// <param name="cancellationToken"></param>
        ///// <returns></returns>
        //Task CreateBucketAsync(string bucketName, string location = "us-east-1", CancellationToken cancellationToken = default);
        ///// <summary>
        ///// 删除桶
        ///// </summary>
        ///// <param name="bucketName"></param>
        ///// <param name="cancellationToken"></param>
        ///// <returns></returns>
        //Task DeleteBucketAsync(string bucketName, CancellationToken cancellationToken = default);
    }
}
