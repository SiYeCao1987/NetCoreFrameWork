using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Log4Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IHostingEnvironment _env;
        private IConfiguration _configuration;
        public ValuesController(IHostingEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //Log4NetUtil.LogDebug(_configuration["envName"].ToString()+ _configuration["testKey"].ToString());
            //Log4NetUtil.LogInfo(_configuration["envName"].ToString() + _configuration["testKey"].ToString());
            return new string[] { "value1", "value2", _env.EnvironmentName, _configuration["envName"].ToString(), _configuration["testKey"].ToString() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
