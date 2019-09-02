using Microsoft.AspNetCore.Mvc;
using MLD.Api.Services;

namespace MLD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = OrderServiceClient.GetOrder(id);
            return Ok(order);
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = OrderServiceClient.GetOrders();
            return Ok(orders);
        }
    }
}
