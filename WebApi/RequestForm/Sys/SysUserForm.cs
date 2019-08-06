using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.RequestForm.Sys
{
    /// <summary>
    /// 
    /// </summary>
    public class SysUserForm
    {
        public string UserName { get; set; }

        public string PassWord { get; set; }

        public int SuperUser { get; set; }

    }
}
