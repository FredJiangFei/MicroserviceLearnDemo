using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shine.API.Models;

namespace Shine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ok");
        }
    }
}
