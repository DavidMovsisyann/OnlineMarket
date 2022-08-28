using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineMarketCore.RepositoryInterfaces;

namespace OnlineMarketCore.RepsitoryInterfaces
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        ICustomerRepository Customer { get; }
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IOrderRepository Order { get; }
        

        Task CompleteAsync();
        Task<IDbContextTransaction> GetTransaction();
    }
}
