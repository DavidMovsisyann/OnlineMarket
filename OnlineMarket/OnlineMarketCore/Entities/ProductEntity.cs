namespace OnlineMarketCore.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }   
        public bool IsDiscounted { get;set; }
        public double Discount { get; set; }

        public CategoryEntity Category {get; set; }
        public ICollection<OrderProductEntity> ProductOrders { get; set; }
    }
}
