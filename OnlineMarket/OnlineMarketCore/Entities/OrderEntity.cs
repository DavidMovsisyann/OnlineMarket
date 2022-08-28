namespace OnlineMarketCore.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset RequierdDate { get; set; }

        public CustomerEntity Customer { get; set; }
        public ICollection<OrderProductEntity> OrderProducts { get; set; }
    }
}
