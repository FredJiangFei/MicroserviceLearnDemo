using Microsoft.AspNetCore.Mvc;

namespace Shine.Services.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("health check ok");
    }
}
