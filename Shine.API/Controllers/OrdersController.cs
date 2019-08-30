using Microsoft.AspNetCore.Mvc;
using Shine.API.Models;
using Shine.API.Services;

namespace Shine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOrders()
        {
            GetMsgSumReply msgSum = MsgServiceClient.GetSum(10, 2);
            return Ok(msgSum.Sum);
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
