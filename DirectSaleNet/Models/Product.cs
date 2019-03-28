using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DirectSaleNet.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        [DisplayName("商品ID")]
        public string ProductName { get; set; }
        [DisplayName("商品名称")]
        public string Brand { get; set; }
        [DisplayName("品牌")]
        public int? StockQuantity { get; set; }
        [DisplayName("库存")]
        public decimal? Price { get; set; }
        [DisplayName("价格")]
        public string Spec { get; set; }
        [DisplayName("Spec")]
        public string Description { get; set; }
        [DisplayName("商品描述")]
        public int ManufactorId { get; set; }

    }
}
