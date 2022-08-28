using Microsoft.EntityFrameworkCore;
using OnlineMarketCore.Entities;
using OnlineMarketCore.RepositoryInterfaces;


namespace OnlineMarketDAL.Repositories
{
    public class OrderRepository:GenericRepository<OrderEntity>,IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context) { }
    }
}
