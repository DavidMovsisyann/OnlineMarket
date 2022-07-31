using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineMarket.DataBase;
using OnlineMarket.RepsitoryInterfaces;

namespace OnlineMarket.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;
        public IUserRepository User { get; }
        public ICustomerRepository Customer { get; }
        public ICategoryRepository Category { get; }
        public IProductRepository Product { get; }
        public IOrderRepository Order { get; }


        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
            User = new UserRepository(_context);
            Customer = new CustomerRepository(_context);
            Category = new CategoryRepository(_context);
            Product = new ProductRepository(_context);
            Order = new OrderRepository(_context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> GetTransaction()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
