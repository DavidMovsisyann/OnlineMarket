
namespace OnlineMarket.Entities
{
    // TODO :: append Entity postfix to all entity names. Eg. Category to CategoryEntity
    public class Category
    {
        // TODO :: rename all entities id property name to Id. Eg CategoryId to Id
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
