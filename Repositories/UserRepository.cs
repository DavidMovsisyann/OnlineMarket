using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.Entities;
using OnlineMarket.RequestModels;

namespace OnlineMarket.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DataBaseContext context) : base(context) { }
    }
}
