using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    /// <summary>
    /// 基础请求处理类
    /// </summary>
    public class BaseRequest
    {
        /// <summary>
        /// 请求序列号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 请求来源:H5,安卓,IOS等
        /// </summary>
        public string RequestFrom { get; set; }
    }
}
