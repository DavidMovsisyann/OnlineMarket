using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.Entities;
using OnlineMarket.RequestModels;

namespace OnlineMarket.Repositories
{
    public class UserRepository : GenericRepository<UserModel>, IUserRepository
    {
        public UserRepository(DataBaseContext context) : base(context) { }

        public override async Task Update(UserModel obj)
        {
            try
            {
                var exsisting = await dataBaseContext.Set<UserModel>().Where(x => x.Id == obj.Id).FirstOrDefaultAsync();

                if (exsisting == null)
                    dataBaseContext.Set<UserModel>().Add(obj);

                exsisting.FirstName = obj.FirstName;
                exsisting.LastName = obj.LastName;
                exsisting.Email = obj.Email;
                exsisting.Role = obj.Role;
                exsisting.UserName = obj.UserName;
                exsisting.BirthDate = obj.BirthDate;
                dataBaseContext.Set<UserModel>().Attach(exsisting);
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
                var exsisting = await dataBaseContext.Set<UserModel>().Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (exsisting != null)
                {
                    dataBaseContext.Set<UserModel>().Remove(exsisting);
                }
                dataBaseContext.Set<UserModel>().Remove(exsisting);
            }
            catch
            {
                throw new Exception("Delete method error");
            }
        }

    }
}
