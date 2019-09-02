using Grpc.Core;

namespace MLD.Api.Services
{
    public static class OrderServiceClient
    {
        private static readonly OrderService.OrderServiceClient Client;

        static OrderServiceClient()
        {
            var channel = new Channel("127.0.0.1:40001", ChannelCredentials.Insecure);
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