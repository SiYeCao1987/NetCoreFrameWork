using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    /// <summary>
    /// http请求体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RequestBody<T>
    {
        /// <summary>
        /// 请求序列号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 请求来源:H5,安卓,IOS等
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// 请求时间
        /// </summary>
        public string RequestTime { get; set; }

        /// <summary>
        /// 请求参数体
        /// </summary>
        public T Body { get; set; }
    }
}
