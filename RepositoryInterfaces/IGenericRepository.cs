using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;

namespace OnlineMarket.RepsitoryInterfaces
{
    public interface IGenericRepository<T>
    {

        Task<List<T>> GetAll();
        Task<T> GetById(int Id);
        Task Insert(T obj);
        Task Update(T obj);
        Task Delete(int Id);

    }
}