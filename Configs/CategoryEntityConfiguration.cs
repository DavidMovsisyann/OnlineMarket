using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarket.Model;
namespace OnlineMarket.Configs
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(p => p.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(20);
            builder.Property(p => p.Description)
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
            builder.HasKey(p => p.CategoryId);
            
        }
    }
}
