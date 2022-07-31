using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.RepsitoryInterfaces;
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

        public Task<List<T>> GetAll()
        {
            return dataBaseContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int Id)
        {
            return await dataBaseContext.Set<T>().FindAsync(Id);
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
