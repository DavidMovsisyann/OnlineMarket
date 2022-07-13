namespace OnlineMarket.Model
{
    public class Customers
    {
        public int CustomerId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Addres { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
