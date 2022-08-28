using OnlineMarketCore.RequestModels;

namespace OnlineMarket.ServiceInterfaces
{
    public interface ICategoriesService
    {
        Task AddCategory(CategoryModel Category);
        Task UpdateCategory(CategoryModel Category);
        Task DeleteCategory(CategoryModel Category);
        Task<CategoryModel> GetCategoryById(int id);
        Task<IEnumerable<CategoryModel>> GetCategories();
    }
}
