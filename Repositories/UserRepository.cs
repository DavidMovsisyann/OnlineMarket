using OnlineMarket.DataBase;
using OnlineMarket.Entities;
using System.Data.Entity;

namespace OnlineMarket.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataBaseContext context) : base(context) { }

        public override async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await table.ToListAsync();
            }
            catch
            {
                throw new Exception("GetAll method exception");
                return new List<User>();
            }
        }

        public override async Task Update(User obj)
        {
            try
            {
                var exsisting = await table.Where(x => x.Id == obj.Id).FirstOrDefaultAsync();

                if (exsisting == null)
                    table.Add(obj);

                exsisting.FirstName = obj.FirstName;
                exsisting.LastName = obj.LastName;
                exsisting.Email = obj.Email;
                exsisting.Customer = obj.Customer;
                exsisting.Role = obj.Role;
                exsisting.UserName = obj.UserName;
                exsisting.BirthDate = obj.BirthDate;
            }
            catch 
            {
                throw new Exception("Update method error");
            }
        }

        public override async Task Delete(int Id)
        {
            try
            {
                var exsisting = await table.Where(x => x.Id == Id).FirstOrDefaultAsync();
                table.Remove(exsisting);
            }
            catch 
            {
                throw new Exception("Delete method error");
            }
        }

    }
}
