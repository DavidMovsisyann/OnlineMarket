using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OnlineMarket.Entities;
using OnlineMarket.Entities.EntityConfigurations;
namespace OnlineMarket.DataBase
{
    // TODO :: Always fix tabulation(ctrl + K + D) and remove unused code parts especially usings
    public class DataBaseContext : DbContext
    {
        // TODO :: replace this construxtor with DataBaseContext(DbContextOptions options) : base(options)
        // it will take opportunity to configure Context from the outside(service registration and injection)
        public DataBaseContext() : base()
        {
        }

        // TODO :: remove this method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO :: SqlServer injection move to program.cs
            // TODO :: connection string move to appsettings.json
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-5UBHVEE\SQLEXPRESS;Initial Catalog=OnlineMarket;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityConfig());
            modelBuilder.ApplyConfiguration(new ProductEntityConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            

        }

        // TODO :: make Pluralize, because you have collections here
        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
