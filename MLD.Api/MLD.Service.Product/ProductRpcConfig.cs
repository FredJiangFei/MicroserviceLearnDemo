using System;
using Consul;
using Grpc.Core;
using MLD.Service.Product.Services;

namespace MLD.Service.Product
{
    public static class ProductRpcConfig
    {
        private static readonly string Address = "127.0.0.1";
        private static readonly string ApiName = "ProductApi";
        private static readonly int Port = 40002;

        public static void Start()
        {
            Console.Title = ApiName;

            var server = new Server
            {
                Services = { ProductService.BindService(new ProductServiceImpl()) },
                Ports = { new ServerPort(Address, Port, ServerCredentials.Insecure) }
            };
            server.Start();

            ConsulConfig();

            Console.WriteLine($"grpc ServerListening On Port {Port}");
            Console.WriteLine("任意键退出...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }

        private static void ConsulConfig()
        {
            var registration = new AgentServiceRegistration()
            {
                Address = Address,
                ID = $"{ApiName}_{Address}:{Port}",
                Name = ApiName,
                Port = Port
            };
            var consul = new ConsulClient();
            consul.Agent.ServiceRegister(registration).GetAwaiter().GetResult();
        }
    }
}
