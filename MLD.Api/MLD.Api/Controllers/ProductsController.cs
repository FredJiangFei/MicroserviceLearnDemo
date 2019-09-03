using Microsoft.AspNetCore.Mvc;
using MLD.Api.Services;

namespace MLD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            var productsReply = ProductServiceClient.GetProducts();
            return Ok(productsReply.Products);
        }
    }
}
