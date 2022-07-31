namespace OnlineMarket.Entities
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Addres { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }

        public UserEntity User { get; set; }
        public ICollection<OrderEntity> Order { get; set; }
    }
}
