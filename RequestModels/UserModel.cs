using OnlineMarket.Entities;
using OnlineMarket.Enums.EntityEnums;

namespace OnlineMarket.RequestModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public UserRoles Role { get; set; }
    }
}
