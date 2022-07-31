using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OnlineMarket.Entities;
using OnlineMarket.Entities.EntityConfigurations;
namespace OnlineMarket.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options){ }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityConfig());
            modelBuilder.ApplyConfiguration(new ProductEntityConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
    }
}
