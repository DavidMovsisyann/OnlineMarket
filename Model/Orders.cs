
namespace OnlineMarket.Model
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequierdDate { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public int Discount { get; set; }
    }
}
