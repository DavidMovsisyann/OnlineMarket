using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using System.Threading.Tasks;
namespace OnlineMarket.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public DataBaseContext dataBaseContext = null;
        public DbSet<T> table = null;

        public GenericRepository()
        {
            dataBaseContext = new DataBaseContext();
            table = dataBaseContext.Set<T>();
        }
        public GenericRepository(DataBaseContext context)
        {
            context = dataBaseContext;
            table = dataBaseContext.Set<T>();
        }
        public virtual async Task Delete(int Id)
        {
            throw new NotImplementedException();

        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return table.ToList();
        }

        public virtual async Task<T> GetById(int Id)
        {
            return await table.FindAsync(Id);
        }

        public virtual async Task Insert(T obj)
        {
            table.Attach(obj);
        }


        public virtual async Task Update(T obj)
        {
            throw new NotImplementedException();
        }
    
    }
}
