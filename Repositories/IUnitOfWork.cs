using Microsoft.EntityFrameworkCore;

namespace OnlineMarket.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        ICustomerRepository Customer { get; }
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IOrderRepository Orders { get; }
        

        Task CompleteAsync();
    }
}
