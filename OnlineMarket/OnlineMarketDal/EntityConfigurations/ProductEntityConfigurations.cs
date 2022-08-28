using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarketCore.Entities;
namespace OnlineMarketDALEntities.EntityConfigurations
{
    public class ProductEntityConfigurations : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
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
            .WithMany(c => c.Products)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
