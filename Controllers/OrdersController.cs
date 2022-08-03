using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Entities;
using OnlineMarket.RequestModels;
using OnlineMarket.Services;

namespace OnlineMarket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        private readonly OrdersService _service;

        public OrdersController(OrdersService service)
        {
            _service = service;
        }

        [HttpGet("id")]
        public async Task<OrderModel> GetOrderById(int id)
        {
            return await _service.GetOrderById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<OrderModel>> GetOrders()
        {
            return await _service.GetOrders();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] OrderModel order)
        {
            await _service.AddOrder(order);
            return Ok();
        }

        [HttpDelete("Id")]
        public async Task DeleteOrder(int id)
        {
            var order = await _service.GetOrderById(id);
            await _service.DeleteOrder(order);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderModel order)
        {
            await _service.UpdateOrder(order);
            return Ok();
        }
    }
}
