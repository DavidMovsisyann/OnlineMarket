using Microsoft.EntityFrameworkCore;
using OnlineMarket.Repositories;

namespace OnlineMarket.RepsitoryInterfaces
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        ICustomerRepository Customer { get; }
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IOrderRepository Order { get; }
        

        Task CompleteAsync();
    }
}
