using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.Entities;

namespace OnlineMarket.Repositories
{
    public class CustomerRepository:GenericRepository<CustomerEntity>,ICustomerRepository
    {
        public CustomerRepository(DataBaseContext context):base(context){ }

        public  async Task<IEnumerable<CustomerEntity>> GetAll()
        {
            try
            {
                return await dataBaseContext.Set<CustomerEntity>().ToListAsync();
            }
            catch
            {
                throw new Exception("Get all method error");
                return new List<CustomerEntity>();
            }
        }

        public override async Task Update(CustomerEntity obj)
        {
            try
            {
                var exsisting = await dataBaseContext.Set<CustomerEntity>().Where(x => x.Id == obj.Id).FirstOrDefaultAsync();

                if (exsisting == null)
                    dataBaseContext.Set<CustomerEntity>().Add(obj);

                exsisting.PhoneNumber = obj.PhoneNumber;
                exsisting.Addres = obj.Addres;
                exsisting.Order = obj.Order;
                exsisting.User = obj.User;
                exsisting.UserId = obj.UserId;
                exsisting.City = obj.City;
                exsisting.Country = obj.Country;
                dataBaseContext.Set<CustomerEntity>().Attach(exsisting);
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
                var exsisting = await dataBaseContext.Set<CustomerEntity>().Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (exsisting != null)
                {
                    dataBaseContext.Set<CustomerEntity>().Remove(exsisting);
                }
                dataBaseContext.Set<CustomerEntity>().Remove(exsisting);
            }
            catch
            {
                throw new Exception("Delete method error");
            }
        }
    }
}
