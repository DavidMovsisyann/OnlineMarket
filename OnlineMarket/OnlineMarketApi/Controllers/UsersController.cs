using Microsoft.AspNetCore.Mvc;
using OnlineMarketCore.RequestModels;
using OnlineMarketBLL.Services;
using AutoMapper;
namespace OnlineMarketApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly UsersService _service;

        public UsersController(UsersService service,IMapper mapper)
        {
            _service = service;
        }
        //Dont working with {Id}
        [HttpGet("Id")]
        public async Task<UserModel> GetUserById(int id)
        {
            return await _service.GetUserById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            return await _service.GetUsers();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserModel user)
        {
            await _service.AddUser(user);
            return Ok();
        }

        [HttpDelete("Id")]
        public async Task DeleteUser(int id) 
        {
           var user = await _service.GetUserById(id);
           await _service.DeleteUser(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody]UserModel user)
        {
            await _service.UpdateUser(user);
            return Ok();
        }
    }
}
