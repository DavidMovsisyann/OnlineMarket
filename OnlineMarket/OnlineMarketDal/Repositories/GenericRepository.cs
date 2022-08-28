using Microsoft.EntityFrameworkCore;
using OnlineMarketCore.RepsitoryInterfaces;
using System.Linq.Expressions;

namespace OnlineMarketDAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext _dataBaseContext;


        public GenericRepository(DbContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public void Delete(T obj)
        {
            var dbEntityEntry = _dataBaseContext.Entry(obj);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate,int skip = 0,int? take = null)
        {
            var query = _dataBaseContext.Set<T>().Where(predicate).Skip(skip);
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }
            return await query.ToListAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _dataBaseContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task Insert(T obj)
        {
            _dataBaseContext.Set<T>().Add(obj);
        }


        public async Task Update(T obj)
        {
            _dataBaseContext.Set<T>().Update(obj);
        }

    }
}
