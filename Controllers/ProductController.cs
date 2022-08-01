using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Entities;
using OnlineMarket.RequestModels;
using OnlineMarket.Services;

namespace OnlineMarket.Controllers
{
    public class ProductController : Controller
    {
        private readonly Service service;

        public ProductController(Service _service)
        {
            service = _service;
        }

        [HttpGet("Id")]
        public async Task<ProductEntity> GetProductById(int id)
        {
            return await service.GetProductById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<ProductEntity>> GetProducts()
        {
            return await service.GetProducts();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductModel product)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductEntity, ProductModel>());
            var mapper = new Mapper(config);
            ProductModel _product = mapper.Map<ProductModel>(product);
            await service.AddProduct(_product);
            return Ok();
        }

        [HttpDelete("Id")]
        public async Task DeleteUser(int id)
        {
            await service.DeleteUser(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductModel product)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductEntity, ProductModel>());
            var mapper = new Mapper(config);
            ProductModel _product = mapper.Map<ProductModel>(product);
            await service.UpdateProduct(_product);
            return Ok();
        }
    }
}
