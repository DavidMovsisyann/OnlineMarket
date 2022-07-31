using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.Entities;

namespace OnlineMarket.Repositories
{
    public class OrderRepository:GenericRepository<OrderEntity>,IOrderRepository
    {
        public OrderRepository(DataBaseContext context) : base(context) { }

        public  async Task<IEnumerable<OrderEntity>> GetAll()
        {
            try
            {
                return await dataBaseContext.Set<OrderEntity>().ToListAsync();
            }
            catch
            {
                throw new Exception("Get all method error");
                return new List<OrderEntity>();
            }
        }

        public override async Task Update(OrderEntity obj)
        {
            try
            {
                var exsisting = await dataBaseContext.Set<OrderEntity>().Where(x => x.Id == obj.Id).FirstOrDefaultAsync();

                if (exsisting == null)
                    dataBaseContext.Set<OrderEntity>().Add(obj);

                exsisting.OrderDate = obj.OrderDate;
                exsisting.RequierdDate=obj.RequierdDate;
                exsisting.ProductId = obj.ProductId;
                exsisting.ProductCount = obj.ProductCount;
                exsisting.Customer = obj.Customer;
                exsisting.CustomerId = obj.CustomerId;
                exsisting.Discount = obj.Discount;
                dataBaseContext.Set<OrderEntity>().Attach(exsisting);
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
                var exsisting = await dataBaseContext.Set<OrderEntity>().Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (exsisting != null)
                {
                    dataBaseContext.Set<OrderEntity>().Remove(exsisting);
                }
                dataBaseContext.Set<OrderEntity>().Remove(exsisting);
            }
            catch
            {
                throw new Exception("Delete method error");
            }
        }
    }
}
