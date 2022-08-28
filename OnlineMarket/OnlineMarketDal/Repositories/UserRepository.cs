using Microsoft.EntityFrameworkCore;
using OnlineMarketCore.RepositoryInterfaces;
using OnlineMarketCore.Entities;

namespace OnlineMarketDAL.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }
    }
}
