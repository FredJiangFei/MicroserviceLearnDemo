using System;
using System.Collections.Generic;
using System.Text;
using Grpc.Core;
using MLD.Service.Order.Services;

namespace MLD.Service.Order
{
    public static class RpcConfig
    {
        private static Server _server;

        public static void Start()
        {
            _server = new Server
            {
                Services = { OrderService.BindService(new OrderServiceImpl()) },
                Ports = { new ServerPort("localhost", 40001, ServerCredentials.Insecure) }
            };
            _server.Start();

            Console.WriteLine("grpc ServerListening On Port 40001");
            Console.WriteLine("任意键退出...");
            Console.ReadKey();

            _server?.ShutdownAsync().Wait();
        }
    }
}
