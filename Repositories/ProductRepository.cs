using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.Entities;


namespace OnlineMarket.Repositories
{
    public class ProductRepository:GenericRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(DataBaseContext context) : base(context) { }

        public override async Task Delete(int Id)
        {
            try
            {
                var exsisting = await dataBaseContext.Set<ProductEntity>().Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (exsisting != null)
                {
                    dataBaseContext.Set<ProductEntity>().Remove(exsisting);
                }
                dataBaseContext.Set<ProductEntity>().Remove(exsisting);
            }
            catch
            {
                throw new Exception("Delete method error");
            }
        }
    }
}
