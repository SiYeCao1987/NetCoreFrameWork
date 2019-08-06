using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    /// <summary>
    /// 服务层返回值
    /// </summary>
    [Serializable]
    public class ServiceResult
    {

        public ServiceResult()
        {
        }

        public ServiceResult(string action)
        {
            this.Action = action;
        }

        /// <summary>
        /// 数据字典
        /// </summary>
        public Dictionary<string, object> DicData { get; set; }

        public void SetData(string key, object val)
        {
            if (DicData == null)
                DicData = new Dictionary<string, object>();
            if (DicData.ContainsKey(key))
                DicData[key] = val;
            else
                DicData.Add(key, val);
        }

        /// <summary>
        /// 服务名称
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 业务目标是否成功
        /// </summary>
        public bool IsSuccess
        {
            get;set;
        }

        /// <summary>
        /// 服务执行信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 设置服务执行信息（重设）
        /// </summary>
        /// <param name="msg"></param>
        public void SetMessage(string msg)
        {
            this.Message = msg;
        }

        /// <summary>
        /// 设置服务执行为【业务成功】，一般用于服务执行的返回结果
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public ServiceResult IsOK(string msg = null)
        {
            if (string.IsNullOrWhiteSpace(this.Message))
            {
                this.SetMessage(this.Action + "操作成功");
            }

            if (msg != null)
                this.SetMessage(msg);

            this.IsSuccess = true;
            return this;
        }

        /// <summary>
        /// 设置服务执行为【业务失败】(但无异常)，一般用于服务执行的返回结果
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public ServiceResult IsFailure(string msg = null)
        {
            if (msg != null)
                this.SetMessage(msg);
            this.IsSuccess = false;
            return this;
        }
    }
}
