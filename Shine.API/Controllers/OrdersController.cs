using System;
using System.Collections.Generic;
using Consul;
using Microsoft.AspNetCore.Mvc;
using Shine.API.Models;

namespace Shine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(OrderRequest request)
        {
            return Ok();
        }
    }
}
