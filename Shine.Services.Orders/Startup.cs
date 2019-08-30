using System;
using System.Linq;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shine.API.Service;

namespace Shine.Services.Orders
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
            services.Configure<ServiceDisvoveryOptions>(Configuration.GetSection("ServiceDiscovery"));
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(cfg =>
            {
                var opt = p.GetRequiredService<IOptions<ServiceDisvoveryOptions>>().Value;

                if (!string.IsNullOrEmpty(opt.Consul.HttpEndpoint))
                {
                    cfg.Address = new Uri(opt.Consul.HttpEndpoint);
                }
            }));
        }

        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            IApplicationLifetime appLife,
            ILoggerFactory loggerFactory,
            IOptions<ServiceDisvoveryOptions> serviceOptions,
            IConsulClient consul)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            // var features = app.Properties["server.Features"] as FeatureCollection;
            // var addresses = features.Get<IServerAddressesFeature>()
            //     .Addresses
            //     .Select(p => new Uri(p));

            // foreach (var address in addresses)
            // {
            //     var serviceId = $"{serviceOptions.Value.ServiceName}_{address.Host}:{address.Port}";

            //     var httpCheck = new AgentServiceCheck()
            //     {
            //         DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
            //         Interval = TimeSpan.FromSeconds(10),
            //         HTTP = new Uri(address, "api/health").OriginalString,
            //         Timeout = TimeSpan.FromSeconds(5)
            //     };

            //     var registration = new AgentServiceRegistration()
            //     {
            //         Checks = new[] { httpCheck },
            //         Address = address.Host,
            //         ID = serviceId,
            //         Name = serviceOptions.Value.ServiceName,
            //         Port = address.Port,
            //         Tags = new string[] { "Order" }
            //     };

            //     consul.Agent.ServiceRegister(registration).GetAwaiter().GetResult();

            //     appLife.ApplicationStopping.Register(() =>
            //     {
            //         consul.Agent.ServiceDeregister(serviceId).GetAwaiter().GetResult();
            //     });
            // }
        }
    }
}
