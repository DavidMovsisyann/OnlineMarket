using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.Entities;

namespace OnlineMarket.Repositories
{
    public class OrderRepository:GenericRepository<OrderEntity>,IOrderRepository
    {
        public OrderRepository(DataBaseContext context) : base(context) { }

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
