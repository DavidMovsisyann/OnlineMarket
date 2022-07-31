using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.Entities;

namespace OnlineMarket.Repositories
{
    public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(DataBaseContext context) : base(context) { }

        public async Task<IEnumerable<CategoryEntity>> GetAll()
        {
            try
            {
                return await dataBaseContext.Set<CategoryEntity>().ToListAsync();
            }
            catch
            {
                throw new Exception("Get all method error");
                return new List<CategoryEntity>();
            }
        }

        public override async Task Update(CategoryEntity obj)
        {
            try
            {
                var exsisting = await dataBaseContext.Set<CategoryEntity>().Where(x => x.Id == obj.Id).FirstOrDefaultAsync();

                if (exsisting == null)
                    dataBaseContext.Set<CategoryEntity>().Add(obj);

                exsisting.Description = obj.Description;
                exsisting.Name = obj.Name;
                dataBaseContext.Set<CategoryEntity>().Attach(exsisting);
            }
            catch
            {
                throw new Exception("Update method error");
            }
        }
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