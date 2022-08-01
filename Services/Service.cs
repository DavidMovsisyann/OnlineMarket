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
        private UserEntity userEntity = new UserEntity();
        private CategoryEntity categoryEntity = new CategoryEntity();
        private ProductEntity productEntity = new ProductEntity();
        private OrderEntity orderEntity = new OrderEntity();

        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddUser(UserModel user)
        {
            await _unitOfWork.User.Insert(userEntity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateUser(UserModel user)
        {
                await _unitOfWork.User.Update(userEntity);
                await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteUser(int id)
        {
                await _unitOfWork.User.Delete(id);
                await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<UserEntity>> GetUsers()
        {
            return await _unitOfWork.User.GetAll(x => x.Id > 0, 0, null); 
        }

        public async Task<UserEntity> GetUserById(int id)
        {
            return await _unitOfWork.User.Get(x => x.Id == id);
        }

        public async Task AddCategory(CategoryModel category)
        {
            await _unitOfWork.Category.Insert(categoryEntity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteCategory(int id)
        {
            await _unitOfWork.Category.Delete(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateCategory(CategoryModel category)
        {
            await _unitOfWork.Category.Update(categoryEntity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<CategoryEntity>> GetCategories()
        {
            return await _unitOfWork.Category.GetAll(x => x.Id > 0, 0, null);
        }

        public async Task<CategoryEntity> GetCategoryById(int id)
        {
            return await _unitOfWork.Category.Get(x => x.Id == id);
        }

        public async Task AddProduct(ProductModel product)
        {
            await _unitOfWork.Product.Insert(productEntity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteProduct(int id)
        {
            await _unitOfWork.Product.Delete(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetProducts()
        {
            return await _unitOfWork.Product.GetAll(x => x.Id > 0, 0, null);
        }

        public async Task<ProductEntity> GetProductById(int id)
        {
            return await _unitOfWork.Product.Get(x => x.Id == id);
        }

        public async Task UpdateProduct(ProductModel product)
        {
            await _unitOfWork.Product.Update(productEntity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task AddOrder(OrderModel order)
        {
            await _unitOfWork.Order.Insert(orderEntity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteOrder(int id)
        {
            await _unitOfWork.Order.Delete(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<OrderEntity> GetOrderById(int id)
        {
            return await _unitOfWork.Order.Get(x => x.Id == id);
        }

        public async Task<IEnumerable<OrderEntity>> GetOrders()
        {
            return await _unitOfWork.Order.GetAll(x => x.Id > 0, 0, null);
        }

        public async Task UpdateOrder(OrderModel order)
        {
            await _unitOfWork.Order.Update(orderEntity);
            await _unitOfWork.CompleteAsync();
        }
    }
}
