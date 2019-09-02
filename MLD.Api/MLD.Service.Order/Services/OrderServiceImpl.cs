using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;

namespace MLD.Service.Order.Services
{
    public class OrderServiceImpl : OrderService.OrderServiceBase
    {
        public override async Task<GetOrderReply> GetOrder(GetOrderRequest request, ServerCallContext context)
        {
            var result = new GetOrderReply
            {
                Id = 1,
                Amount = 123
            };
            return result;
        }

        public override async Task<GetOrdersReply> GetOrders(GetOrdersRequest request, ServerCallContext context)
        {
            var result = new GetOrdersReply
            {
            };
            return result;
        }
    }
}