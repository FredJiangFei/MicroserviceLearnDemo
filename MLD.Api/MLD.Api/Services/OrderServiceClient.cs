namespace MLD.Api.Services
{
    public static class OrderServiceClient
    {
        private static readonly OrderService.OrderServiceClient Client;

        static OrderServiceClient()
        {
            var channel = ServiceClientHelper.GetChannelByApiName("OrderApi");
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