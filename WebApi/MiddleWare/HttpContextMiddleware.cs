using Common.Helper;
using Common.Log4Net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.MiddleWare
{
    /// <summary>
    /// Http 请求中间件
    /// </summary>
    public class HttpContextMiddleware
    {
        /// <summary>
        /// 处理HTTP请求
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// 构造 Http 请求中间件
        /// </summary>
        /// <param name="next"></param>
        public HttpContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 执行响应流指向新对象
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableBuffering();
            var api = new HttpContextMessage
            {
                RequestMethod = context.Request.Method,
                ResponseStatusCode = context.Response.StatusCode,
                RequestQurey = context.Request.QueryString.ToString(),
                RequestContextType = context.Request.ContentType,
                RequestHost = context.Request.Host.ToString(),
                RequestPath = context.Request.Path,
                RequestScheme = context.Request.Scheme,
                RequestLocalIp = (context.Request.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString() + ":" + context.Request.HttpContext.Connection.LocalPort),
                RequestRemoteIp = (context.Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString() + ":" + context.Request.HttpContext.Connection.RemotePort)
            };

            var request = context.Request.Body;
            var response = context.Response.Body;
            //请求序列号
            string serialNumber = "";
            try
            {
                using (var newRequest = new MemoryStream())
                {
                    //替换request流
                    context.Request.Body = newRequest;

                    using (var newResponse = new MemoryStream())
                    {
                        //替换response流
                        context.Response.Body = newResponse;

                        using (var reader = new StreamReader(request))
                        {
                            //读取原始请求流的内容
                            api.RequestBody = await reader.ReadToEndAsync();
                            if (string.IsNullOrEmpty(api.RequestBody))
                            {
                                await _next.Invoke(context);
                            }
                            else
                            {
                                JObject jObject = JObject.Parse(api.RequestBody);
                                if (jObject["SerialNumber"] != null)
                                {
                                    serialNumber = jObject["SerialNumber"].ToString();
                                }
                            }
                        }

                        using (var writer = new StreamWriter(newRequest))
                        {
                            await writer.WriteAsync(api.RequestBody);
                            await writer.FlushAsync();
                            newRequest.Position = 0;
                            context.Request.Body = newRequest;
                            await _next(context);
                        }

                        using (var reader = new StreamReader(newResponse))
                        {
                            newResponse.Position = 0;
                            api.ResponseBody = await reader.ReadToEndAsync();
                            try
                            {
                                JObject resJObect = JObject.Parse(api.ResponseBody);
                                resJObect["SerialNumber"] = serialNumber;
                                api.ResponseBody = resJObect.ToJson();
                            }
                            catch
                            {
                                
                            }
                        }

                        context.Response.Clear();

                        using (var writer = new StreamWriter(response))
                        {
                            await writer.WriteAsync(api.ResponseBody);
                            await writer.FlushAsync();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ResponseResult responseResult = new ResponseResult();
                responseResult.SerialNumber = serialNumber;
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status200OK;
                responseResult.Code = ResponseResultType.Error;
                responseResult.Message = "对不起，系统开小差了！！！";
                //记录异常
                Log4NetUtil.LogError("全局捕获异常SerialNumber:" + responseResult.SerialNumber, ex);
                using (var writer = new StreamWriter(response))
                {
                    await writer.WriteAsync(responseResult.ToJson());
                    await writer.FlushAsync();
                }
            }
            finally
            {
                context.Request.Body = request;
                context.Response.Body = response;
            }

            // 响应完成时存入缓存
            context.Response.OnCompleted(() =>
            {
                //记录响应报文
                Log4NetUtil.LogDebug(api.ToString());
                return Task.CompletedTask;
            });
        }
    }
}
