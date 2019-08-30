using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shine.API.Models;
using System.IO;
using Google.Protobuf;
using Grpc.Core;

namespace Shine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {

            return Ok();
            // var consulClient = new ConsulClient(c => c.Address = new Uri("http://127.0.0.1:8500"));
            // var services = consulClient.Agent.Services().Result.Response;
            // var orderApiService = services.FirstOrDefault(x => x.Value.Tags.Any(t => t == "Order"));
            // using (var client = new HttpClient())
            // {
            //     var serviceResult = await client.GetStringAsync(
            //         $"http://{orderApiService.Value.Address}:{orderApiService.Value.Port}/api/orders");
            //     return Ok(serviceResult);
            // }
        }

        [HttpPost]
        public IActionResult Post(OrderRequest request)
        {
            return Ok();
        }
    }
}
