using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarket.Model;
namespace OnlineMarket.Configs
{
    public class AdminsEntityConfigurations : IEntityTypeConfiguration<Admins>
    {
        public void Configure(EntityTypeBuilder<Admins> builder)
        {
            builder.Property(p => p.AdminUserName)
                .HasColumnType("nvarchar")
                .HasMaxLength(30);
            builder.HasKey(p => p.AdminId);
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
            builder.HasMany(a => a.Users)
                .WithMany(u => u.Admins);
        }
    }
}
