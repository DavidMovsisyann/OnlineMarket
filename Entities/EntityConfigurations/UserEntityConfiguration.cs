using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarket.Entities;

namespace OnlineMarket.Entities.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {

        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {

            builder.ToTable("User");
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
            // OR
            builder
                .Property(p => p.Email)
                .HasColumnType("NVARCHAR(25)");
            builder
                .Property(p => p.BirthDate)
                .HasColumnType("Date");
            builder
                .HasKey(user => user.Id);
        }
    }
}
