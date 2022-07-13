using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarket.Model;
namespace OnlineMarket.Configs
{
    public class ProductsEntityConfigurations : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.Property(p => p.ProductName)
                  .HasColumnType("nvarchar")
                  .HasMaxLength(30);
            builder.Property(p => p.IsDiscounted)
                  .HasColumnType("bit")
                  .HasDefaultValue(false);
            builder.Property(p => p.Price)
                  .HasColumnType("decimal")
                  .HasPrecision(16,6);
            builder.Property(p => p.Discount)
                  .HasColumnType("decimal")
                  .HasPrecision(16, 6);
            builder.Property(p => p.Count)
                  .HasColumnType("int");
            builder.HasKey(p => p.Id);
            

        }
    }
}
