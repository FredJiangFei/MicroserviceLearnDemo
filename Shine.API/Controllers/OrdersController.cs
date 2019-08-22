using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shine.API.Models;

namespace Shine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(OrderRequest request)
        {
            return Ok();
        }
    }
}
