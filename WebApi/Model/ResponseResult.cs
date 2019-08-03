using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    /// <summary>
    /// WebApi统一响应处理类
    /// </summary>
    public class ResponseResult
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 消息描述
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 实体数据
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 请求序列号
        /// </summary>
        public string SerialNumber { get; set; }
    }
}
