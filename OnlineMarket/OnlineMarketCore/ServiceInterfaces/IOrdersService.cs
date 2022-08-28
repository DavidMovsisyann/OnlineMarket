using OnlineMarketCore.RequestModels;

namespace OnlineMarket.ServiceInterfaces
{
    public interface IOrdersService
    {
        Task AddOrder(OrderModel Order);
        Task UpdateOrder(OrderModel Order);
        Task DeleteOrder(OrderModel Order);
        Task<OrderModel> GetOrderById(int id);
        Task<IEnumerable<OrderModel>> GetOrders();
    }
}
