using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.Entities;

namespace OnlineMarket.Repositories
{
    public class OrderRepository:GenericRepository<OrderEntity>,IOrderRepository
    {
        public OrderRepository(DataBaseContext context) : base(context) { }
    }
}
