using Microsoft.EntityFrameworkCore;
using OnlineMarketCore.Entities;
using OnlineMarketCore.Enums.EntityEnums;
using OnlineMarketDal.DataBase;
using OnlineMarketDAL.Repositories;

namespace OnlineMarket.Tests
{
    public class Tests
    {
        private DataBaseContext _dataBase;
        private UserRepository _userRepository;

        [SetUp]
        public void Setup()
        {
            var databaseName = "DataBaseContext";
            var _dbContextOptions = new DbContextOptionsBuilder<DataBaseContext>()
           .UseInMemoryDatabase(databaseName)
           .EnableDetailedErrors()
           .EnableSensitiveDataLogging()
           .Options;
            _dataBase = new DataBaseContext(_dbContextOptions);
            _userRepository = new UserRepository(_dataBase);

        }

        [Test]
        public void InsertTest()
        {
            //Arrange 
            UserEntity user = new UserEntity();
            void AddUser(string FirstName, string LastName, string UserName, string Password, string Email, DateTime BirthDate, UserRoles Role)
            {
                user.FirstName = FirstName;
                user.LastName = LastName;
                user.UserName = UserName;
                user.Password = Password;
                user.Email = Email;
                user.BirthDate = BirthDate;
                user.Role = Role;
            }
            //Act      
            AddUser("David", "Movsisyan", "DavMov", "Davv22", "davitmovsisyan@gmail.com", new DateTime(2007, 3, 29), UserRoles.Admin);
            _userRepository.Insert(user);
            //Assert
            Assert.IsTrue(_dataBase.Users.FirstOrDefault().Id == user.Id && _dataBase.Users.FirstOrDefault().UserName == user.UserName);
        }
        [Test]
        public void UpdateTest()
        {
            //Arrange 
            UserEntity user = new UserEntity();
            void AddUser(string FirstName, string LastName, string UserName, string Password, string Email, DateTime BirthDate, UserRoles Role)
            {
                user.FirstName = FirstName;
                user.LastName = LastName;
                user.UserName = UserName;
                user.Password = Password;
                user.Email = Email;
                user.BirthDate = BirthDate;
                user.Role = Role;
            }
            //Act      
            AddUser("David", "Movsisyan", "DavMov", "Davv22", "davitmovsisyan@gmail.com", new DateTime(2007, 3, 29), UserRoles.Admin);
            _userRepository.Insert(user);
            UserEntity UpdateUser(string FirstName, string LastName, string UserName, string Password, string Email, DateTime BirthDate, UserRoles Role)
            {
                user.FirstName = FirstName;
                user.LastName = LastName;
                user.UserName = UserName;
                user.Password = Password;
                user.Email = Email;
                user.BirthDate = BirthDate;
                user.Role = Role;
                return user;
            }
            _userRepository.Update(UpdateUser("David", "Movsisyan", "DavMov", "Davv22", "davitmovsisyan44@gmail.com", new DateTime(2007, 3, 29), UserRoles.Customer));
            //Assert
            Assert.IsTrue(_dataBase.Users.FirstOrDefault().Id == user.Id && _dataBase.Users.FirstOrDefault().UserName == user.UserName);
        }
        [Test]
        public void GetTest()
        {
            //Arrange 
            UserEntity user = new UserEntity();
            void AddUser(string FirstName, string LastName, string UserName, string Password, string Email, DateTime BirthDate, UserRoles Role)
            {
                user.FirstName = FirstName;
                user.LastName = LastName;
                user.UserName = UserName;
                user.Password = Password;
                user.Email = Email;
                user.BirthDate = BirthDate;
                user.Role = Role;
            }
            //Act      
            AddUser("David", "Movsisyan", "DavMov", "Davv22", "davitmovsisyan@gmail.com", new DateTime(2007, 3, 29), UserRoles.Admin);
            _userRepository.Insert(user);
            async Task<UserEntity> GetUserByIdAsync(int id)
            {
                var _user = _userRepository.Get(x => x.Id == id);
                return await _user;
            }
            var User = GetUserByIdAsync(2).GetAwaiter().GetResult();
            //Assert
            Assert.IsTrue(User == user);
        }
    }
}