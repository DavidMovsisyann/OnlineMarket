using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.RepsitoryInterfaces;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace OnlineMarket.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DataBaseContext dataBaseContext;


        public GenericRepository(DataBaseContext context)
        {
            dataBaseContext = context;
        }

        public virtual async Task Delete(int Id)
        {
            throw new NotImplementedException();

        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate,int skip = 0,int? take = null)
        {
            var query = dataBaseContext.Set<T>().Where(predicate).Skip(skip);
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }
            return await query.ToListAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await dataBaseContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task Insert(T obj)
        {
            dataBaseContext.Set<T>().Add(obj);
        }


        public virtual async Task Update(T obj)
        {
            dataBaseContext.Set<T>().Update(obj);
        }

    }
}
