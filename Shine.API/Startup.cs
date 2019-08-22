using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Shine.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(x => x.WithOrigins("http://localhost:4200")
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials());
            app.UseMvc();


            String ip = Configuration["ip"];
            Int32 port = Int32.Parse(Configuration["port"]);

            ConsulClient client = new ConsulClient(ConfigurationOverview);
            Task<WriteResult> result = client.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID = "apiservice1" + Guid.NewGuid(),
                Name = "apiservice1",
                Address = ip,
                Port = port,
                Check = new AgentServiceCheck()
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                    Interval = TimeSpan.FromSeconds(10),
                    HTTP = $"http://{ip}:{port}/api/health",
                    Timeout = TimeSpan.FromSeconds(5)
                }
            });
        }

        private static void ConfigurationOverview(ConsulClientConfiguration obj)
        {
            obj.Address = new Uri("http://127.0.0.1:8500");
            obj.Datacenter = "dc1";
        }
    }
}
