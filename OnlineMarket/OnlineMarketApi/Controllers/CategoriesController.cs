using Microsoft.AspNetCore.Mvc;
using OnlineMarketCore.RequestModels;
using OnlineMarketBLL.Services;

namespace OnlineMarketApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        private readonly CategoriesService _service;

        public CategoriesController(CategoriesService service)
        {
            _service = service;
        }

        [HttpGet("id")]
        public async Task<CategoryModel> GetCategoryrById(int id)
        {
            return await _service.GetCategoryById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            return await _service.GetCategories();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryModel category)
        {
            await _service.AddCategory(category);
            return Ok();
        }

        [HttpDelete("Id")]
        public async Task DeleteCategory(int id)
        {
            var category = await _service.GetCategoryById(id);
            await _service.DeleteCategory(category);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryModel category)
        {
            await _service.UpdateCategory(category);
            return Ok();
        }
    }
}
