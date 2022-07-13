using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OnlineMarket.Model;
using OnlineMarket.Configs;
namespace OnlineMarket.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-5UBHVEE\SQLEXPRESS;Initial Catalog=OnlineMarket;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomersEntityConfig());
            modelBuilder.ApplyConfiguration(new ProductsEntityConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AdminsEntityConfigurations());

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Admins> Admins { get; set; }
    }
}
