using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketCore.Entities
{
    public class OrderProductEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get;set; }
        public int Count { get; set; }
        public int Discount { get; set; }
        public int Price { get; set; }

        public OrderEntity Order { get; set; }
        public ProductEntity Product { get; set; }
    }
}
