using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Google.Protobuf;
using Grpc.Core;

namespace Shine.Services.Orders
{
    public class Program
    {
        public static void Main(string[] args)
        {

            CreateWebHostBuilder(args)
            .UseUrls($"http://127.0.0.1:8080")
            .Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
