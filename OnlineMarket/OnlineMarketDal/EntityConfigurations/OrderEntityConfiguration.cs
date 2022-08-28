using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarketCore.Entities;
namespace OnlineMarketDALEntities.EntityConfigurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(o => o.Customer)
                .WithMany(o => o.Order)
                .HasForeignKey(c=>c.CustomerId);
        }
    }
}
