namespace OnlineMarket.Model
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }   
        public bool IsDiscounted { get;set; }
        public double Discount { get; set; }
    }
}
