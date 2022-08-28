using OnlineMarketCore.RequestModels;

namespace OnlineMarket.ServiceInterfaces
{
    public interface IUsersService
    {
        Task AddUser(UserModel user);
        Task UpdateUser(UserModel user);
        Task DeleteUser(UserModel user);
        Task<UserModel> GetUserById(int id);
        Task<IEnumerable<UserModel>> GetUsers();
    }
}
