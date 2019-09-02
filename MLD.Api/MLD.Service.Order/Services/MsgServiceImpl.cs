using System.Threading.Tasks;
using Grpc.Core;

namespace MLD.Service.Order.Services
{
    public class MsgServiceImpl : MsgService.MsgServiceBase
    {
        public override async Task<GetMsgSumReply> GetSum(GetMsgNumRequest request, ServerCallContext context)
        {
            var result = new GetMsgSumReply
            {
                Sum = request.Num1 + request.Num2
            };
            return result;
        }
    }
}