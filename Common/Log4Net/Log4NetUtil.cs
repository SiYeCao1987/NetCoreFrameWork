using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Log4Net
{
    /// <summary>
    /// 日志工具类
    /// </summary>
    public class Log4NetUtil
    {
        //Error处理类
        private static readonly ILog ErrorLog = LogManager.GetLogger(Log4NetConfig.RepositoryName, "Error");

        //Info处理类
        private static readonly ILog InfoLog = LogManager.GetLogger(Log4NetConfig.RepositoryName, "Info");

        //Debug处理类
        private static readonly ILog DebugLog = LogManager.GetLogger(Log4NetConfig.RepositoryName, "Debug");

        //Warn处理类
        private static readonly ILog WarnLog = LogManager.GetLogger(Log4NetConfig.RepositoryName, "Warn");

        /// <summary>
        /// Error记录持久化
        /// </summary>
        /// <param name="throwMsg"></param>
        /// <param name="ex"></param>
        public static void LogError(string throwMsg, Exception ex)
        {
            var errorMsg =
                $"【抛出信息】：{throwMsg} \r\n【异常类型】：{ex.GetType().Name} \r\n【异常信息】：{ex.Message} \r\n【堆栈调用】：\r\n{ex.StackTrace}";
            ErrorLog.Error(errorMsg);
        }

        /// <summary>
        /// info记录持久化
        /// </summary>
        /// <param name="msg"></param>
        public static void LogInfo(string msg)
        {
            InfoLog.Info(msg);
        }

        /// <summary>
        /// Debug记录持久化
        /// </summary>
        /// <param name="msg"></param>
        public static void LogDebug(string msg)
        {
            DebugLog.Debug(msg);
        }

        /// <summary>
        /// Warn记录持久化
        /// </summary>
        /// <param name="msg"></param>
        public static void LogWarn(string msg)
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine(msg);
            sb.AppendLine("----------------------------------------");
            WarnLog.Warn(sb.ToString());
        }
    }
}
