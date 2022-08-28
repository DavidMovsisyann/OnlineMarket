using Microsoft.EntityFrameworkCore;
using OnlineMarketCore.Entities;
using OnlineMarketCore.RepositoryInterfaces;

namespace OnlineMarketDAL.Repositories
{
    public class ProductRepository:GenericRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context) { }
    }
}
