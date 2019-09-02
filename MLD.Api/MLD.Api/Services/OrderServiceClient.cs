using System;
using System.Linq;
using System.Net.Http;
using Consul;
using Grpc.Core;

namespace MLD.Api.Services
{
    public static class OrderServiceClient
    {
        private static readonly OrderService.OrderServiceClient Client;

        static OrderServiceClient()
        {
            var consulClient = new ConsulClient(c => c.Address = new Uri("http://127.0.0.1:8500"));
            var services = consulClient.Agent.Services().Result.Response;
            var orderService = services.FirstOrDefault(x => x.Value.Service == "OrderApi");

            var channel = new Channel(
                $"{orderService.Value.Address}:{orderService.Value.Port}", 
                ChannelCredentials.Insecure);
            Client = new OrderService.OrderServiceClient(channel);
        }

        public static GetOrderReply GetOrder(int id)
        {
            return Client.GetOrder(new GetOrderRequest
            {
                Id = id
            });
        }

        public static GetOrdersReply GetOrders()
        {
            return Client.GetOrders(new GetOrdersRequest());
        }
    }
}