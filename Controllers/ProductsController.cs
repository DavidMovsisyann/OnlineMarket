using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Entities;
using OnlineMarket.RequestModels;
using OnlineMarket.Services;

namespace OnlineMarket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductsService _service;

        public ProductsController(ProductsService service)
        {
            _service = service;
        }

        [HttpGet("id")]
        public async Task<ProductModel> GetProductById(int id)
        {
            return await _service.GetProductById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            return await _service.GetProducts();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductModel product)
        {
            await _service.AddProduct(product);
            return Ok();
        }

        [HttpDelete("Id")]
        public async Task DeleteProduct(int id)
        {
            var product = await _service.GetProductById(id);
            await _service.DeleteProduct(product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductModel product)
        {
            await _service.UpdateProduct(product);
            return Ok();
        }
    }
}
