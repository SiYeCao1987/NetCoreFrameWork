using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.RequestForm
{
    public class DemoForm : BaseRequest
    {
        public string Message { get; set; }
    }
}
