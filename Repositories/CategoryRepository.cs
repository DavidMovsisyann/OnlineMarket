using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.Entities;

namespace OnlineMarket.Repositories
{
    public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(DataBaseContext context) : base(context) { }

        public override async Task Delete(int Id)
        {
            try
            {
                var exsisting = await dataBaseContext.Set<CategoryEntity>().Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (exsisting!=null)
                {
                    dataBaseContext.Set<CategoryEntity>().Remove(exsisting);
                }
            }catch
            {
                throw new Exception("Delete method error");
            }
        }
    }
}