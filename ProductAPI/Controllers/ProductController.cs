using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProductAPI.Services;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private IProductsService _service;
        public ProductController(IProductsService service)
        {
            _service = service;
        }

        [HttpGet("getProducts")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetDepthChart()
        {
            return Ok(await _service.GetProducts());
        }

        [HttpPost("addProduct")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest playerDetails)
        {
            return Ok(await _service.AddProducts(playerDetails));
        }

    }
}
