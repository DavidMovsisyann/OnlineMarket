
namespace OnlineMarket.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset RequierdDate { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public int Discount { get; set; }
        public Customer Customer { get; set; }
    }
}
