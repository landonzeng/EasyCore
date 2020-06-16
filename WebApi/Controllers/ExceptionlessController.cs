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
            //Logger.Debug("message!", "tag1", "tag2", "tag3");

            var a = new Test();
            a.test = "aaa";
            var dd = Convert.ToInt32(a.test);

            return Ok();
            //throw new Exception("Test test ts Get测试");
        }

        public class Test
        {
            public string test { get; set; }
        }

        // GET: api/Exceptionless/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            //try
            //{
            throw new Exception($"测试抛出的异常{id}");
            //}
            //catch (Exception ex)
            //{
            //    ex.ToExceptionless().Submit();
            //}
            //return Ok("Unknown Error!");
        }

        // POST: api/Exceptionless
        [HttpPost("{id}")]
        public void Post([FromBody] PutModel putModel)
        {
            throw new Exception("Test test ts Post测试");
        }

        // PUT: api/Exceptionless/5
        [HttpPut("{id}")]
        public void Put([FromBody] PutModel putModel)
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

    /// <summary>
    ///
    /// </summary>
    public class PutModel
    {
        /// <summary>
        ///
        /// </summary>
        public string u_id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string user { get; set; }
    }
}