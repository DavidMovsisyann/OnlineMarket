using AutoMapper;
using OnlineMarketCore.RepsitoryInterfaces;
using OnlineMarketCore.RequestModels;
using OnlineMarket.ServiceInterfaces;
using OnlineMarketCore.Entities;

namespace OnlineMarketBLL.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrdersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddOrder(OrderModel order)
        {
            OrderEntity _order = _mapper.Map<OrderEntity>(order);
            OrderProductEntity orderProduct = new OrderProductEntity();
            var productId = orderProduct.ProductId;
            var product = await _unitOfWork.Product.Get(x => x.Id == productId);
            var transaction = await _unitOfWork.GetTransaction();
            try
            {
                await _unitOfWork.Order.Insert(_order);
                product.Count -= orderProduct.Count;
                await _unitOfWork.CompleteAsync();
            }
            catch
            {
                transaction.Rollback();
            }
            transaction.Commit();
        }

        public async Task DeleteOrder(OrderModel order)
        {
            OrderEntity _order = _mapper.Map<OrderEntity>(order);
            _unitOfWork.Order.Delete(_order);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateOrder(OrderModel order)
        {
            OrderEntity _order = _mapper.Map<OrderEntity>(order);
            await _unitOfWork.Order.Update(_order);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<OrderModel>> GetOrders()
        {
            var orders = await _unitOfWork.Order.GetAll(x => x.Id > 0, 0, null);
            IEnumerable<OrderModel> _order = _mapper.Map<IEnumerable<OrderModel>>(orders);
            return _order;
        }

        public async Task<OrderModel> GetOrderById(int id)
        {
            var order = await _unitOfWork.Order.Get(x => x.Id == id);
            OrderModel _order = _mapper.Map<OrderModel>(order);
            return _order;
        }
    }
}
