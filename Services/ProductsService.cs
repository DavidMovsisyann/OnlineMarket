using AutoMapper;
using OnlineMarket.Entities;
using OnlineMarket.RepsitoryInterfaces;
using OnlineMarket.RequestModels;
using OnlineMarket.ServiceInterfaces;

namespace OnlineMarket.Services
{
    public class ProductsService:IProductsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddProduct(ProductModel product)
        {
            ProductEntity _product = _mapper.Map<ProductEntity>(product);
            await _unitOfWork.Product.Insert(_product);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteProduct(ProductModel product)
        {
            ProductEntity _product = _mapper.Map<ProductEntity>(product);
            _unitOfWork.Product.Delete(_product);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateProduct(ProductModel product)
        {
            ProductEntity _product = _mapper.Map<ProductEntity>(product);
            await _unitOfWork.Product.Update(_product);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            var products = await _unitOfWork.Product.GetAll(x => x.Id > 0, 0, null);
            IEnumerable<ProductModel> _product = _mapper.Map<IEnumerable<ProductModel>>(products);
            return _product;
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            var Product = await _unitOfWork.Product.Get(x => x.Id == id);
            ProductModel _Product = _mapper.Map<ProductModel>(Product);
            return _Product;
        }
    }
}
