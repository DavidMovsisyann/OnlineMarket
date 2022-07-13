using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarket.Model;
namespace OnlineMarket.Configs
{
    public class CustomersEntityConfig : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.ToTable("Customers");
            builder
                .Property(p => p.Country)
                .HasColumnType("nvarchar")
                .HasMaxLength(25);
            builder.Property(p => p.City)
                .HasColumnType("nvarchar")
                .HasMaxLength(20);
            builder.Property(p => p.Addres)
               .HasColumnType("nvarchar")
               .HasMaxLength(35);
            builder.Property(p => p.PhoneNumber)
                .HasColumnType("nvarchar")
                .HasMaxLength(15);
            builder.HasKey(p=>p.CustomerId);
        }

        
    }
}
