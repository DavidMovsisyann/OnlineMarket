using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarket.Model;

namespace OnlineMarket
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<Users>
    {

        public void Configure(EntityTypeBuilder<Users> builder)
        {

            builder.ToTable("Users");
            builder
                 .Property(p => p.FirstName)
                 .HasColumnType("nvarchar")
                 .HasMaxLength(15);
            builder.Property(p => p.Password)
                .HasColumnType("nvarchar")
                .HasMaxLength(30);
            builder
                .Property(p => p.LastName)
                .HasColumnType("nvarchar")
                .HasMaxLength(25);
            builder
                .Property(p => p.UserName)
                .HasColumnType("nvarchar")
                .HasMaxLength(25);
            builder
                .Property(p => p.Email)
                .HasColumnType("nvarchar")
                .HasMaxLength(25);
            builder
                .Property(p => p.BirthDate)
                .HasColumnType("Date");
            builder
                .HasKey(user => user.Id);

        }
    }
}
