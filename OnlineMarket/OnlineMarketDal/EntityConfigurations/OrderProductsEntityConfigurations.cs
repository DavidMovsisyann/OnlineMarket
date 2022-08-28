using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarketCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketDal.EntityConfigurations
{
    public class OrderProductsEntityConfigurations : IEntityTypeConfiguration<OrderProductEntity>
    {
        public void Configure(EntityTypeBuilder<OrderProductEntity> builder)
        {
            builder.HasKey(e => new {e.ProductId,e.OrderId });
            builder.HasOne(p => p.Product).WithMany(o => o.ProductOrders).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(o=>o.Order).WithMany(o => o.OrderProducts).HasForeignKey(x=>x.OrderId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
