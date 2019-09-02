using System;
using Consul;
using Grpc.Core;
using MLD.Service.Order.Services;

namespace MLD.Service.Order
{
    public static class OrderRpcConfig
    {
        public static void Start()
        {
            var address = "127.0.0.1";
            var port = 40001;
            var server = new Server
            {
                Services = { OrderService.BindService(new OrderServiceImpl()) },
                Ports = { new ServerPort(address, port, ServerCredentials.Insecure) }
            };
            server.Start();

            ConsulConfig(address, port);

            Console.WriteLine($"grpc ServerListening On Port {port}");
            Console.WriteLine("任意键退出...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }

        private static void ConsulConfig(string address, int port)
        {
            var registration = new AgentServiceRegistration()
            {
                Address = address,
                ID = $"OrderApi_{address}:{port}",
                Name = "OrderApi",
                Port = port
            };
            var consul = new ConsulClient();
            consul.Agent.ServiceRegister(registration).GetAwaiter().GetResult();
        }
    }
}
