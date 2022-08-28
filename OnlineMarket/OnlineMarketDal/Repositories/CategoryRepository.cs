using Microsoft.EntityFrameworkCore;
using OnlineMarketCore.Entities;
using OnlineMarketCore.RepositoryInterfaces;

namespace OnlineMarketDAL.Repositories
{
    public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context) { }
    }
}