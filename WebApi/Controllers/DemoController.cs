using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Helper;
using Common.Log4Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebApi.Model;
using WebApi.RequestForm;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DemoController : ApiBaseController
    {
        private IHostingEnvironment _env;

        public DemoController(IHostingEnvironment env)
        {
          
            _env = env;
        }

        [HttpPost]
        public ActionResult HelloWorld([FromBody]DemoForm demoForm)
        {
            ResponseResult response = new ResponseResult();
            DemoModel demoModel = new DemoModel();
            demoModel.UserName = demoForm.Message;
            if (string.IsNullOrEmpty(demoForm.SerialNumber))
            {
                Log4NetUtil.LogWarn(demoForm.ToJson());
                response.Code = ResponseResultType.ParamError;
                response.Message = "参数错误";
                return Content(response.ToJson());
            }

           
            response.Code = ResponseResultType.Success;
            response.Message = _env.EnvironmentName;
            response.Data = demoModel;

            return Content(response.ToJson());
        }
    }

    public class DemoModel
    {
        public string UserName { get; set; }
        public string Remark { get; set; }
    }
}