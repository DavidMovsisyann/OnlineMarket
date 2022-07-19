using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;

namespace OnlineMarket.Repositories
{
    public interface IGenericRepository<T>
    {

        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int Id);
        Task Insert(T obj);
        Task Update(T obj);
        Task Delete(int Id);
    }
}
