﻿namespace OnlineMarketCore.RequestModels
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public bool IsDiscounted { get; set; }
        public double Discount { get; set; }
    }
}
