using System;
using Grpc.Core;
using MLD.Service.Order.Services;

namespace MLD.Service.Order
{
    public static class OrderRpcConfig
    {
        public static void Start()
        {
            var server = new Server
            {
                Services = { OrderService.BindService(new OrderServiceImpl()) },
                Ports = { new ServerPort("localhost", 40001, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("grpc ServerListening On Port 40001");
            Console.WriteLine("任意键退出...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
