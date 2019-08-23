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

namespace Shine.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // https://cecilphillip.com/using-consul-for-service-discovery-with-asp-net-core/
        // http://michaco.net/blog/ServiceDiscoveryAndHealthChecksInAspNetCoreWithConsul
        // https://www.c-sharpcorner.com/article/dynamic-asp-net-core-configurations-with-consul-kv/
        // https://github.com/PlayFab/consuldotnet

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<ServiceDisvoveryOptions>(Configuration.GetSection("ServiceDiscovery"));
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(cfg =>
            {
                var serviceConfiguration = p.GetRequiredService<IOptions<ServiceDisvoveryOptions>>().Value;

                if (!string.IsNullOrEmpty(serviceConfiguration.Consul.HttpEndpoint))
                {
                    cfg.Address = new Uri(serviceConfiguration.Consul.HttpEndpoint);
                }
            }));
        }

        public void Configure(
            IApplicationBuilder app,
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
            app.UseCors(x => x.WithOrigins("http://localhost:4200")
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials());
            app.UseMvc();


            var features = app.Properties["server.Features"] as FeatureCollection;
            var addresses = features.Get<IServerAddressesFeature>()
                .Addresses
                .Select(p => new Uri(p));

            foreach (var address in addresses)
            {
                var serviceId = $"{serviceOptions.Value.ServiceName}_{address.Host}:{address.Port}";

                var httpCheck = new AgentServiceCheck()
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                    Interval = TimeSpan.FromSeconds(10),
                    HTTP = new Uri(address, "api/health").OriginalString,
                    Timeout = TimeSpan.FromSeconds(5)
                };

                var registration = new AgentServiceRegistration()
                {
                    Checks = new[] { httpCheck },
                    Address = address.Host,
                    ID = serviceId,
                    Name = serviceOptions.Value.ServiceName,
                    Port = address.Port
                };

                consul.Agent.ServiceRegister(registration).GetAwaiter().GetResult();

                appLife.ApplicationStopping.Register(() =>
                {
                    consul.Agent.ServiceDeregister(serviceId).GetAwaiter().GetResult();
                });
            }
        }
    }
}
