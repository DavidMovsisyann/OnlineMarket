using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.Entities;

namespace OnlineMarket.Repositories
{
    public class OrderRepository:GenericRepository<Order>,IOrderRepository
    {
        public OrderRepository(DataBaseContext context) : base(context) { }

        public override async Task<IEnumerable<Order>> GetAll()
        {
            try
            {
                return await table.ToListAsync();
            }
            catch
            {
                throw new Exception("Get all method error");
                return new List<Order>();
            }
        }

        public override async Task Update(Order obj)
        {
            try
            {
                var exsisting = await table.Where(x => x.OrderId == obj.OrderId).FirstOrDefaultAsync();

                if (exsisting == null)
                    table.Add(obj);

                exsisting.OrderDate = obj.OrderDate;
                exsisting.RequierdDate=obj.RequierdDate;
                exsisting.ProductId = obj.ProductId;
                exsisting.ProductCount = obj.ProductCount;
                exsisting.Customer = obj.Customer;
                exsisting.CustomerId = obj.CustomerId;
                exsisting.Discount = obj.Discount;
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
                var exsisting = await table.Where(x => x.OrderId == Id).FirstOrDefaultAsync();
                table.Remove(exsisting);
            }
            catch
            {
                throw new Exception("Delete method error");
            }
        }
    }
}
