using AutoMapper;
using OnlineMarket.Entities;
using OnlineMarket.RepsitoryInterfaces;
using OnlineMarket.RequestModels;
using OnlineMarket.ServiceInterfaces;

namespace OnlineMarket.Services
{
    public class CategoriesService:ICategoriesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriesService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddCategory(CategoryModel category)
        {
            CategoryEntity _category = _mapper.Map<CategoryEntity>(category);
            await _unitOfWork.Category.Insert(_category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteCategory(CategoryModel category)
        {
            CategoryEntity _category = _mapper.Map<CategoryEntity>(category);
            _unitOfWork.Category.Delete(_category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateCategory(CategoryModel category)
        {
            CategoryEntity _category = _mapper.Map<CategoryEntity>(category);
            await _unitOfWork.Category.Update(_category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            var categories = await _unitOfWork.Category.GetAll(x => x.Id > 0, 0, null);
            IEnumerable<CategoryModel> _category = _mapper.Map<IEnumerable<CategoryModel>>(categories);
            return _category;
        }

        public async Task<CategoryModel> GetCategoryById(int id)
        {
            var category = await _unitOfWork.Category.Get(x => x.Id == id);
            CategoryModel _category = _mapper.Map<CategoryModel>(category);
            return _category;
        }

    }
}
