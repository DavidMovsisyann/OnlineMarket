using Microsoft.EntityFrameworkCore;
using OnlineMarketCore.Entities;
using OnlineMarketCore.RepositoryInterfaces;

namespace OnlineMarketDAL.Repositories
{
    public class CustomerRepository:GenericRepository<CustomerEntity>,ICustomerRepository
    {
        public CustomerRepository(DbContext context):base(context){ }
    }
}
