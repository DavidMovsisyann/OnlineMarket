using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarketCore.Entities;
namespace OnlineMarketDALEntities.EntityConfigurations
{
    public class CustomerEntityConfig : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.ToTable("Customer");
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
            builder.HasKey(p=>p.Id);

            builder.HasOne(p => p.User)
                .WithOne(p => p.Customer)
                .HasForeignKey<CustomerEntity>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        
    }
}
