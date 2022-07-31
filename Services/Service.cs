using OnlineMarket.Entities;
using OnlineMarket.Repositories;
using OnlineMarket.Enums.EntityEnums;
using OnlineMarket.RepsitoryInterfaces;
using OnlineMarket.RequestModels;

namespace OnlineMarket.Services
{
    public class Service
    {
        private readonly IUnitOfWork _unitOfWork;


        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddUser(UserModel user)
        {
            await _unitOfWork.User.Insert(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateUser(UserModel user)
        {
            if (user.Role == UserRoles.Admin)
            {
                await _unitOfWork.User.Update(user);
                await _unitOfWork.CompleteAsync();
            }
            else
            {
                throw new Exception("You don't have permisions for (Update User)");
            }
        }

        public async Task DeleteUser(int id)
        {
            var existing = await _unitOfWork.User.GetById(id);

            if (existing.Role == UserRoles.Customer)
            {
                await _unitOfWork.User.Delete(id);
                await _unitOfWork.CompleteAsync();
            }
            else
            {
                throw new Exception("You don't have permisions for (Delete User)");
            }
        }

        public async Task<IEnumerable<UserModel>> GetUsers(int id)
        {
            var existing = await _unitOfWork.User.GetById(id);

            if (existing.Role == UserRoles.Admin)
            {
                return await _unitOfWork.User.GetAll();
            }
            else
            {
                throw new Exception("You don't have permisions for (Get Users)");
            }
        }

        public async Task<UserModel> GetUserById(int id)
        {
            var existing = await _unitOfWork.User.GetById(id);

            if (existing.Role == UserRoles.Admin)
            {
                return await _unitOfWork.User.GetById(id);
            }
            else
            {
                throw new Exception("You don't have permisions for (Get User By Id)");
            }
        }

        public async Task AddCategory(CategoryEntity category)
        {
            await _unitOfWork.Category.Insert(category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteCategory(int id)
        {
            await _unitOfWork.Category.Delete(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateCategory(CategoryEntity category)
        {
            await _unitOfWork.Category.Update(category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<CategoryEntity>> GetCategories()
        {
            return await _unitOfWork.Category.GetAll();
        }

        public async Task<CategoryEntity> GetCategoryById(int id)
        {
            return await _unitOfWork.Category.GetById(id);
        }

        public async Task AddProduct(ProductEntity product)
        {
            await _unitOfWork.Product.Insert(product);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteProduct(int id)
        {
            await _unitOfWork.Product.Delete(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetProducts()
        {
            return await _unitOfWork.Product.GetAll();
        }

        public async Task<ProductEntity> GetProductById(int id)
        {
            return await _unitOfWork.Product.GetById(id);
        }

        public async Task UpdateProduct(ProductEntity product)
        {
            await _unitOfWork.Product.Update(product);
            await _unitOfWork.CompleteAsync();
        }

        public async Task AddOrder(OrderEntity order)
        {
            await _unitOfWork.Order.Insert(order);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteOrder(int id)
        {
            await _unitOfWork.Order.Delete(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<OrderEntity> GetOrderById(int id)
        {
            return await _unitOfWork.Order.GetById(id);
        }

        public async Task<IEnumerable<OrderEntity>> GetOrders()
        {
            return await _unitOfWork.Order.GetAll();
        }

        public async Task UpdateOrder(OrderEntity order)
        {
            await _unitOfWork.Order.Update(order);
            await _unitOfWork.CompleteAsync();
        }
    }
}
