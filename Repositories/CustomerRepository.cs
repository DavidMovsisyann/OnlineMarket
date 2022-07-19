using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.Entities;

namespace OnlineMarket.Repositories
{
    public class CustomerRepository:GenericRepository<Customer>,ICustomerRepository
    {
        public CustomerRepository(DataBaseContext context):base(context){ }

        public override async Task<IEnumerable<Customer>> GetAll()
        {
            try
            {
                return await table.ToListAsync();
            }
            catch
            {
                throw new Exception("Get all method error");
                return new List<Customer>();
            }
        }

        public override async Task Update(Customer obj)
        {
            try
            {
                var exsisting = await table.Where(x => x.CustomerId == obj.CustomerId).FirstOrDefaultAsync();

                if (exsisting == null)
                    table.Add(obj);

                exsisting.PhoneNumber = obj.PhoneNumber;
                exsisting.Addres = obj.Addres;
                exsisting.Order = obj.Order;
                exsisting.User = obj.User;
                exsisting.UserId = obj.UserId;
                exsisting.City = obj.City;
                exsisting.Country = obj.Country;
                
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
                var exsisting = await table.Where(x => x.CustomerId == Id).FirstOrDefaultAsync();
                table.Remove(exsisting);
            }
            catch
            {
                throw new Exception("Delete method error");
            }
        }
    }
}
