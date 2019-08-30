using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Google.Protobuf;
using Grpc.Core;
using Shine.Services.Orders.Services;

namespace Shine.Services.Orders
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Server _server = new Server
            {
                Services = { MsgService.BindService(new MsgServiceImpl()) },
                Ports = { new ServerPort("127.0.0.1", 40001, ServerCredentials.Insecure) }
            };
            _server.Start();

            CreateWebHostBuilder(args)
            .UseUrls($"http://127.0.0.1:8080")
            .Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
