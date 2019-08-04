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
using WebApi.InjectTest;
using WebApi.Model;
using WebApi.RequestForm;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DemoController : ApiBaseController
    {
        private IHostingEnvironment _env;

        /// <summary>
        /// 测试属性注入
        /// </summary>
        public Iperson iperson { get; set; }

        public DemoController(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public ActionResult<string> GetName()
        {
            ResponseResult response = new ResponseResult();
            response.Message = iperson.GetName();
            return iperson.GetName();

        }

        [HttpPost]
        public ActionResult GetName1()
        {
            ResponseResult response = new ResponseResult();
            response.Message = iperson.GetName();
            response.Code = ResponseResultType.Success;
            DemoModel demo = new DemoModel();
            demo.UserName = "1";
            response.Data = demo;
            return Content(response.ToJson());

        }

        [HttpPost]
        public ActionResult HelloWorld(DemoForm demoForm)
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

            response.SerialNumber = "2";
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