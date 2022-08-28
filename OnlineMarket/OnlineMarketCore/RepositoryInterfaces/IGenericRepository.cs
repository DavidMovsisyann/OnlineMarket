using System.Linq.Expressions;

namespace OnlineMarketCore.RepsitoryInterfaces
{
    public interface IGenericRepository<T>
    {

        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate,int skip,int? take);
        Task<T> Get(Expression<Func<T, bool>> predicate);
        Task Insert(T obj);
        Task Update(T obj);
        void Delete(T obj);

    }
}