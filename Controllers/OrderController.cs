using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Entities;
using OnlineMarket.RequestModels;
using OnlineMarket.Services;

namespace OnlineMarket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly Service service;

        public OrderController(Service _service)
        {
            service = _service;
        }

        [HttpGet("Id")]
        public async Task<OrderEntity> GetOrderById(int id)
        {
            return await service.GetOrderById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<OrderEntity>> GetOrders()
        {
            return await service.GetOrders();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] OrderModel order)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderEntity, OrderModel>());
            var mapper = new Mapper(config);
            OrderModel _order = mapper.Map<OrderModel>(order);
            await service.AddOrder(_order);
            return Ok();
        }

        [HttpDelete("Id")]
        public async Task DeleteOrder(int id)
        {
            await service.DeleteOrder(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderModel order)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderEntity, OrderModel>());
            var mapper = new Mapper(config);
            OrderModel _order = mapper.Map<OrderModel>(order);
            await service.UpdateOrder(_order);
            return Ok();
        }
    }
}
