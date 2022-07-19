using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarket.Entities;
namespace OnlineMarket.Entities.EntityConfigurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            
            builder.Property(p=>p.Discount)
                .HasColumnType("decimal")
                .HasPrecision(14,4);
            builder.HasKey(p => p.OrderId);
            builder.HasOne(o => o.Customer)
                .WithMany(o => o.Order).HasForeignKey(c=>c.CustomerId);
        }
    }
}
