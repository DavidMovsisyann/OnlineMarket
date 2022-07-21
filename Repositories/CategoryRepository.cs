using OnlineMarket.DataBase;
using OnlineMarket.Entities;
using System.Data.Entity;

namespace OnlineMarket.Repositories
{
    // TODO :: Always divide interfaces and implementation into different folders
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(DataBaseContext context) : base(context) { }

        public override async Task<IEnumerable<Category>> GetAll()
        {
            try 
            {
                return await table.ToListAsync();
            }
            catch
            {
                throw new Exception("Get all method error");
                return new List<Category>();
            }
        }

        public override async Task Update(Category obj)
        {
            try
            {
                var exsisting = await table.Where(x => x.CategoryId == obj.CategoryId).FirstOrDefaultAsync();

                if (exsisting == null)
                    table.Add(obj);

                exsisting.Description = obj.Description;
                exsisting.Product = obj.Product;
                exsisting.Name = obj.Name;
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
                var exsisting = await table.Where(x => x.CategoryId == Id).FirstOrDefaultAsync();
                table.Remove(exsisting);
            }
            catch
            {
                throw new Exception("Delete method error");
            }
        }
    }
}
