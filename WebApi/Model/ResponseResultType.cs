using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    /// <summary>
    /// 响应处理类型
    /// </summary>
    public class ResponseResultType
    {
        /// <summary>
        /// 业务成功
        /// </summary>
        public const int Success = 1000;

        /// <summary>
        /// 业务失败
        /// </summary>
        public const int Fail = 1001;

        /// <summary>
        /// 请求参数异常
        /// </summary>
        public const int ParamError = 1002;

        /// <summary>
        /// 请求异常
        /// </summary>
        public const int Error = 1003;
    }
}
