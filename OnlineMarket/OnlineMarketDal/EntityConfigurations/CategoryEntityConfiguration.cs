using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarketCore.Entities;

namespace OnlineMarketDALEntities.EntityConfigurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.Property(p => p.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(20);
            builder.Property(p => p.Description)
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
            builder.HasKey(p => p.Id);
            
        }
    }
}
