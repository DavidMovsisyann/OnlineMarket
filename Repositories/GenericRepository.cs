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

        // TODO :: async method name violation. Append Async postfix after every async method.
        // Here you used ToList(), which is not async, why did you use Task<...> and async method?
        // You need to replace ToList() with ToListAsync()
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return table.ToList();
        }

        // TODO :: Not all entities have id property. Eg. many to many entities
        // TODO :: 
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

/*
 Suggested solution
  public T Add(T entity)
        {
            Context.Set<T>().Add(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);

            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await Context.Set<T>().AddRangeAsync(entities);
            return entities;
        }

        public IList<T> FindAsync(Expression<Func<T, bool>> predicate, int skip = 0, int? take = null)
        {
            var query = Context.Set<T>().Where(predicate).Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return await query.ToList();
        }

        public async Task<IList<T>> FindAsync(Expression<Func<T, bool>> predicate, int skip = 0, int? take = null)
        {
            var query = Context.Set<T>().Where(predicate).Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return await query.ToListAsync();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().FirstOrDefault(predicate);
        }
 
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public void Remove(T entity)
        {
            var dbEntityEntry = Context.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }

        public virtual void Update(T entity)
        {
            var dbEntityEntry = Context.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            Context.Set<T>().UpdateRange(entities);
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }


        public async Task<IEnumerable<T>> FilterWithIncludeAsync(Expression<Func<T, bool>> whereProperties, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            if (whereProperties != null)
            {
                query = query.Where(whereProperties);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }

        public IEnumerable<T> FilterWithInclude(Expression<Func<T, bool>> whereProperties, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            if (whereProperties != null)
            {
                query = query.Where(whereProperties);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }
 
 */