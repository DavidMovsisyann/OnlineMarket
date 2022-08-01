using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.Entities;
using OnlineMarket.RequestModels;

namespace OnlineMarket.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DataBaseContext context) : base(context) { }

        public override async Task Delete(int Id)
        {
            try
            {
                var exsisting = await dataBaseContext.Set<UserEntity>().Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (exsisting != null)
                {
                    dataBaseContext.Set<UserEntity>().Remove(exsisting);
                }
                dataBaseContext.Set<UserEntity>().Remove(exsisting);
            }
            catch
            {
                throw new Exception("Delete method error");
            }
        }

    }
}
