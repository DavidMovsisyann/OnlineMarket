using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarket.Model;
namespace OnlineMarket.Configs
{
    public class OrdersEntityConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.Property(p=>p.OrderDate)
                .HasColumnType("datetime2");
            builder.Property(p => p.RequierdDate)
                .HasColumnType("datetime2");
            builder.Property(p=>p.Discount)
                .HasColumnType("decimal")
                .HasPrecision(14,4);
            builder.HasKey(p => p.OrderId);
        }
    }
}
