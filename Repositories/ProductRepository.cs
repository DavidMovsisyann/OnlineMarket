using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.Entities;


namespace OnlineMarket.Repositories
{
    public class ProductRepository:GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DataBaseContext context) : base(context) { }

        public override async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                return await table.ToListAsync();
            }
            catch
            {
                throw new Exception("Get all method error");
                return new List<Product>();
            }
        }

        public override async Task Update(Product obj)
        {
            try
            {
                var exsisting = await table.Where(x => x.Id == obj.Id).FirstOrDefaultAsync();

                if (exsisting == null)
                    table.Add(obj);

                exsisting.Discount = obj.Discount;
                exsisting.IsDiscounted = obj.IsDiscounted;
                exsisting.Name = obj.Name;
                exsisting.Price = obj.Price;
                exsisting.Category = obj.Category;
                exsisting.CategoryId = obj.CategoryId;
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
                var exsisting = await table.Where(x => x.Id == Id).FirstOrDefaultAsync();
                table.Remove(exsisting);
            }
            catch
            {
                throw new Exception("Delete method error");
            }
        }
    }
}
