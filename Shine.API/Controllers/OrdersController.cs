using Microsoft.AspNetCore.Mvc;

namespace Shine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public void Post()
        {
            var name ="fred";
        }
    }
}
