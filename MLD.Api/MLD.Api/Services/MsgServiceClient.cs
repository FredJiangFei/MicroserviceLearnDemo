using Grpc.Core;

namespace MLD.Api.Services
{
    public static class MsgServiceClient
    {
        private static readonly MsgService.MsgServiceClient Client;

        static MsgServiceClient()
        {
            var channel = new Channel("127.0.0.1:40001", ChannelCredentials.Insecure);
            Client = new MsgService.MsgServiceClient(channel);
        }

        public static GetMsgSumReply GetSum(int num1, int num2)
        {
            return Client.GetSum(new GetMsgNumRequest
            {
                Num1 = num1,
                Num2 = num2
            });
        }
    }
}