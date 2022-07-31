using Microsoft.AspNetCore.Mvc;
using OnlineMarket.RequestModels;
using OnlineMarket.Services;
namespace OnlineMarket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly Service service;

        public UserController(Service _service)
        {
            service = _service;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            await service.GetUsers(1);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserModel user)
        {
            await service.AddUser(user);
            return Ok();
        }

    }
}
