using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Common.Log4Net;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApi.MiddleWare;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //初始化日志
            Log4NetInit(Configuration);
        }

        private void Log4NetInit(IConfiguration configuration)
        {
            var repositoryName = configuration.GetSection("Log4Net:RepositoryName").Value;
            if (string.IsNullOrWhiteSpace(repositoryName))
            {
                throw new Exception("必须在配置文件中添加 Log4Net > RepositoryName 节点");
            }

            Log4NetConfig.RepositoryName = repositoryName;

            var configFilePath = configuration.GetSection("Log4Net:ConfigFilePath").Value;
            if (string.IsNullOrWhiteSpace(configFilePath))
            {
                configFilePath = "Log4net.config";
            }

            var file = new FileInfo(configFilePath);
            var repository = LogManager.CreateRepository(repositoryName);
            XmlConfigurator.Configure(repository, file);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(o=> {
            }
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //http请求中间件
            app.UseMiddleware<HttpContextMiddleware>();

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
