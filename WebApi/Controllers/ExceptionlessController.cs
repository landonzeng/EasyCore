using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCore.ExceptionlessExtensions;
using Exceptionless;
using Exceptionless.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptionlessController : ControllerBase
    {
        public ILoggerHelper Logger { get; }
        public ExceptionlessController(ILoggerHelper logger)
        {
            Logger = logger;
        }

        // GET: api/Exceptionless
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Logger.Debug("message!", "tag1", "tag2", "tag3");

            return Ok();
            //throw new Exception("Test test ts Get测试");
        }

        // GET: api/Exceptionless/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                throw new Exception($"测试抛出的异常{id}");
            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();
            }
            return Ok("Unknown Error!");

        }

        // POST: api/Exceptionless
        [HttpPost]
        public void Post()
        {
            throw new Exception("Test test ts Post测试");
        }

        // PUT: api/Exceptionless/5
        [HttpPut("{id}")]
        public void Put(int id)
        {
            throw new Exception("Test test ts Put测试");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new Exception("Test test ts Delete测试");
        }
    }
}
