using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineMarket.DataBase;

namespace OnlineMarket.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        // TODO :: please use private field name best practice. start name with _ character. Eg context => _context
        private readonly DataBaseContext context;
        public IUserRepository User { get; }
        public ICustomerRepository Customer { get; }
        public ICategoryRepository Category { get; }
        public IProductRepository Product { get; }
        public IOrderRepository Orders { get; }
        
        // TODO :: You can use singleton patter and init only that repositories, which you will use
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

        // TODO :: I said that you need to replace with context.Database.BeginTransaction();
        // TODO :: you can add  "IsolationLevel level" argument and give to BeginTransaction(level);
        public IDbContextTransaction GetTransaction()
        {
            return  context.Database.CurrentTransaction;
        }
    }
}
