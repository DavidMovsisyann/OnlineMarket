namespace OnlineMarket.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Addres { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
