using AutoMapper;
using OnlineMarketCore.RepsitoryInterfaces;
using OnlineMarketCore.RequestModels;
using OnlineMarket.ServiceInterfaces;
using OnlineMarketCore.Entities;

namespace OnlineMarketBLL.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddUser(UserModel user)
        {
            UserEntity _user = _mapper.Map<UserEntity>(user);
            await _unitOfWork.User.Insert(_user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteUser(UserModel user)
        {
            UserEntity _user = _mapper.Map<UserEntity>(user);
            _unitOfWork.User.Delete(_user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateUser(UserModel user)
        {
            UserEntity _user = _mapper.Map<UserEntity>(user);
            await _unitOfWork.User.Update(_user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var users = await _unitOfWork.User.GetAll(x => x.Id > 0, 0, null);
            IEnumerable<UserModel> _user = _mapper.Map<IEnumerable<UserModel>>(users);
            return _user;
        }

        public async Task<UserModel> GetUserById(int id)
        {
            var user = await _unitOfWork.User.Get(x => x.Id == id);
            UserModel _user = _mapper.Map<UserModel>(user);
            return _user;
        }
    }
}
