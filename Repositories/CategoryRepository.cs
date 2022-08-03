using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.Entities;

namespace OnlineMarket.Repositories
{
    public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(DataBaseContext context) : base(context) { }
    }
}