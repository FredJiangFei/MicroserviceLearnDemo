using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;

namespace MLD.Service.Order.Services
{
    public class OrderServiceImpl : OrderService.OrderServiceBase
    {
        public override async Task<GetOrderReply> GetOrder(GetOrderRequest request, ServerCallContext context)
        {
            var orders = GetOrders();
            var order = orders.Find(x => x.Id == request.Id);
            return order;
        }

        public override async Task<GetOrdersReply> GetOrders(GetOrdersRequest request, ServerCallContext context)
        {
            var orders = GetOrders();
            var result = new GetOrdersReply();
            result.Orders.AddRange(orders);
            return result;
        }

        private List<GetOrderReply> GetOrders()
        {
            return new List<GetOrderReply>
            {
                new GetOrderReply
                {
                    Id = 1,
                    Amount = 123
                },
                new GetOrderReply
                {
                    Id = 2,
                    Amount = 456
                }
            };
        }
    }
}