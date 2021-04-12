using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EasyCore.Minio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel;
using Minio.Exceptions;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinioTestController : ControllerBase
    {
        private const int MB = 1024 * 1024;
        private readonly IMinioRepository _minio;

        public MinioTestController(IMinioRepository minio)
        {
            _minio = minio;
        }

        [HttpGet("api/base64")]
        public async Task<IActionResult> Get()
        {
            string base64String = "";
            try
            {
                string bucketName = "hrms-images";
                string saveName = "gongyi.png";

                await _minio.StatObjectAsync(bucketName, saveName);

                await _minio.GetObjectAsync(bucketName, saveName,
                    (stream) =>
                    {
                        var memoryStream = new MemoryStream();
                        stream.CopyTo(memoryStream);
                        byte[] result = memoryStream.ToArray();
                        base64String = Convert.ToBase64String(result);
                    });

                Console.WriteLine($"Get BucketName Images Base64:\n {base64String} ");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket]  Exception: {e}");
                return NotFound(e.Message);
            }

            return Ok("data:image/jpeg;base64," + base64String);
        }

        [HttpGet]
        public async Task<IActionResult> download()
        {
            try
            {
                string bucketName = "hrms-images";
                string saveName = "gongyi.png";

                var memoryStream = new MemoryStream();

                await _minio.StatObjectAsync(bucketName, saveName);

                await _minio.GetObjectAsync(bucketName, saveName,
                    (stream) =>
                    {
                        stream.CopyTo(memoryStream);
                    });

                return File(memoryStream.ToArray(), System.Net.Mime.MediaTypeNames.Image.Jpeg, "gongyi.png");
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket]  Exception: {e}");
                return NotFound(e.Message);
            }
        }

        // PUT: api/Value
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            try
            {
                string bucketName = "hrms-images";
                string saveName = "gongyi.png";
                string fileName = @"G:\360MoveData\Users\landon\Desktop\gongyi.png";

                byte[] bs = System.IO.File.ReadAllBytes(fileName);
                using (MemoryStream filestream = new MemoryStream(bs))
                {
                    if (filestream.Length < (5 * MB))
                    {
                        Console.WriteLine("Running example for API: PutObjectAsync with Stream");
                    }
                    else
                    {
                        Console.WriteLine("Running example for API: PutObjectAsync with Stream and MultiPartUpload");
                    }

                    var metaData = new Dictionary<string, string>
                    {
                        { "Content-Type", "image/jpeg" }
                        //{ "Content-Type", "application/pdf" }
                    };

                    await _minio.PutObjectAsync(bucketName, saveName, filestream, filestream.Length, "application/octet-stream", metaData);
                }

                Console.WriteLine($"Uploaded object {saveName} to bucket {bucketName}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket]  Exception: {e}");
            }

            string res = "";

            return Ok(res);
        }
    }
}