using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarket.Entities;
namespace OnlineMarket.Entities.EntityConfigurations
{
    public class ProductEntityConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                  .HasColumnType("nvarchar")
                  .HasMaxLength(30);
            builder.Property(p => p.IsDiscounted)
                  .HasColumnType("bit")
                  .HasDefaultValue(false);
            builder.Property(p => p.Price)
                  .HasColumnType("decimal")
                  .HasPrecision(16, 6);
            builder.Property(p => p.Discount)
                  .HasColumnType("decimal")
                  .HasPrecision(16, 6);
            builder.Property(p => p.Count)
                  .HasColumnType("int");
            builder.HasKey(p => p.Id);

            builder.HasOne(s => s.Category)
            .WithMany(c => c.Product)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
