using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using Grpc.Core;

namespace MLD.Api.Services
{
    public class ServiceClientHelper
    {
        public static Channel GetChannelByApiName(string apiName)
        {
            var consulClient = new ConsulClient(c => c.Address = new Uri("http://127.0.0.1:8500"));
            var services = consulClient.Agent.Services().Result.Response;
            var orderService = services.FirstOrDefault(x => x.Value.Service == apiName);

            var channel = new Channel(
                $"{orderService.Value.Address}:{orderService.Value.Port}",
                ChannelCredentials.Insecure);

            return channel;
        }
    }
}
