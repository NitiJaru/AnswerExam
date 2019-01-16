using System;
using System.Collections.Generic;

namespace A2.Lib
{
    public class Cart
    {
        public List<OrderProduct> Products { get; set; }
        public double TotalPriceBeforeDiscount { get; set; }
        public double Discount { get; set; }
        public double TotalPrice { get; set; }
    }
}
