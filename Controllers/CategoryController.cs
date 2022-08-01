using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Entities;
using OnlineMarket.RequestModels;
using OnlineMarket.Services;

namespace OnlineMarket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly Service service;

        public CategoryController(Service _service)
        {
            service = _service;
        }

        [HttpGet("Id")]
        public async Task<CategoryEntity> GetCategoryrById(int id)
        {
            return await service.GetCategoryById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryEntity>> GetCategories()
        {
            return await service.GetCategories();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryModel category)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CategoryEntity, CategoryModel>());
            var mapper = new Mapper(config);
            CategoryModel _category = mapper.Map<CategoryModel>(category);
            await service.AddCategory(_category);
            return Ok();
        }

        [HttpDelete("Id")]
        public async Task DeleteCategory(int id)
        {
            await service.DeleteCategory(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryModel category)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CategoryEntity, CategoryModel>());
            var mapper = new Mapper(config);
            CategoryModel _category = mapper.Map<CategoryModel>(category);
            await service.UpdateCategory(_category);
            return Ok();
        }
    }
}
