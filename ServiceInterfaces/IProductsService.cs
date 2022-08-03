using OnlineMarket.RequestModels;

namespace OnlineMarket.ServiceInterfaces
{
    public interface IProductsService
    {
        Task AddProduct(ProductModel Product);
        Task UpdateProduct(ProductModel Product);
        Task DeleteProduct(ProductModel Product);
        Task<ProductModel> GetProductById(int id);
        Task<IEnumerable<ProductModel>> GetProducts();
    }
}
