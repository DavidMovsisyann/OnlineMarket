using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.Entities;

namespace OnlineMarket.Repositories
{
    public class CustomerRepository:GenericRepository<CustomerEntity>,ICustomerRepository
    {
        public CustomerRepository(DataBaseContext context):base(context){ }

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
