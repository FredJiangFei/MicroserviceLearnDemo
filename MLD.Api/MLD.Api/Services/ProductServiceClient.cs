using System;
using System.Linq;
using System.Net.Http;
using Consul;
using Grpc.Core;

namespace MLD.Api.Services
{
    public static class ProductServiceClient
    {
        private static readonly ProductService.ProductServiceClient Client;

        static ProductServiceClient()
        {
            //var consulClient = new ConsulClient(c => c.Address = new Uri("http://127.0.0.1:8500"));
            //var services = consulClient.Agent.Services().Result.Response;
            //var orderService = services.FirstOrDefault(x => x.Value.Service == "ProductApi");

            //var channel = new Channel(
            //    $"{orderService.Value.Address}:{orderService.Value.Port}", 
            //    ChannelCredentials.Insecure);

            var channel = ServiceClientHelper.GetChannelByApiName("ProductApi");
            Client = new ProductService.ProductServiceClient(channel);
        }

        public static GetProductsReply GetProducts()
        {
            return Client.GetProducts(new GetProductsRequest());
        }
    }
}