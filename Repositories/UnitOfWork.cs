using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineMarket.DataBase;

namespace OnlineMarket.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext context;
        public IUserRepository User { get; }
        public ICustomerRepository Customer { get; }
        public ICategoryRepository Category { get; }
        public IProductRepository Product { get; }
        public IOrderRepository Orders { get; }
        

        public UnitOfWork(DataBaseContext context)
        {
            this.context = context;
            User = new UserRepository(context);
            Customer = new CustomerRepository(context);
            Category = new CategoryRepository(context);
            Product = new ProductRepository(context);
            Orders = new OrderRepository(context);
        }
        
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }

        public IDbContextTransaction GetTransaction()
        {
            return  context.Database.CurrentTransaction;
        }
    }
}
