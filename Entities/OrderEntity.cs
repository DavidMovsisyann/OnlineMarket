namespace OnlineMarket.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset RequierdDate { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public int Discount { get; set; }
        public CustomerEntity Customer { get; set; }
    }
}
