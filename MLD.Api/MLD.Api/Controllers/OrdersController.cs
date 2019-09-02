using Microsoft.AspNetCore.Mvc;
using MLD.Api.Services;

namespace MLD.Api.Controllers
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
        }
    }
}
