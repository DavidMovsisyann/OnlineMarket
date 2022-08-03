using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.Entities;


namespace OnlineMarket.Repositories
{
    public class ProductRepository:GenericRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(DataBaseContext context) : base(context) { }
    }
}
