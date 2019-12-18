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
    public class ValueController : ControllerBase
    {
        private const int MB = 1024 * 1024;
        private readonly IMinioRepository _minio;
        public ValueController(IMinioRepository minio)
        {
            _minio = minio;
        }

        // GET: api/Value
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                string bucketName = "hrms-images";
                string saveName = "概率论基础和随机过程.pdf";
                string fileName = @"G:\360MoveData\Users\landon\Desktop\概率论基础和随机过程.pdf";

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
                        //{ "Content-Type", "image/jpeg" }
                        { "Content-Type", "application/pdf" }
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

        // GET: api/Value/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Value
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Value/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
