using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.Entities;

namespace OnlineMarket.Repositories
{
    public class CustomerRepository:GenericRepository<CustomerEntity>,ICustomerRepository
    {
        public CustomerRepository(DataBaseContext context):base(context){ }
    }
}
