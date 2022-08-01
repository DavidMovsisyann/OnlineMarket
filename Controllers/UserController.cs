using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Entities;
using OnlineMarket.RequestModels;
using OnlineMarket.Services;
using AutoMapper;
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

        [HttpGet("Id")]
        public async Task<UserEntity> GetUserById(int id)
        {
            return await service.GetUserById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<UserEntity>> GetUsers()
        {
            return await service.GetUsers();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserModel user)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserEntity, UserModel>());
            var mapper = new Mapper(config);
            UserModel _user = mapper.Map<UserModel>(user);
            await service.AddUser(_user);
            return Ok();
        }

        [HttpDelete("Id")]
        public async Task DeleteUser(int id) 
        {
           await service.DeleteUser(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody]UserModel user)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserEntity, UserModel>());
            var mapper = new Mapper(config);
            UserModel _user = mapper.Map<UserModel>(user);
            await service.UpdateUser(_user);
            return Ok();
        }
    }
}
