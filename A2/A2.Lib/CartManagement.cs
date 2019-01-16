using System;
using System.Collections.Generic;
using System.Linq;

namespace A2.Lib
{
    public class CartManagement
    {
        public Cart CartInfo { get; private set; }
        public CartManagement() => CartInfo = new Cart { Products = new List<OrderProduct>() };

        public void OrderProduct(OrderProduct product)
        {
            CartInfo.Products.Add(product);

            var TotalPriceBeforeDiscount = 0.00;
            var Discount = 0.00;
            var TotalPrice = 0.00;

            var group = CartInfo.Products.GroupBy(it => it.Name);
            foreach (var item in group)
            {
                var discountAmount = 0;
                foreach (var item_2 in item)
                {
                    discountAmount = item_2.Unit / 4;
                    item_2.TotalPrice = item_2.Unit * item_2.PricePerUnit;
                    TotalPriceBeforeDiscount += item_2.TotalPrice;
                }
                Discount += item.FirstOrDefault().PricePerUnit * discountAmount;
            }
            TotalPrice = TotalPriceBeforeDiscount - Discount;

            CartInfo.TotalPriceBeforeDiscount = TotalPriceBeforeDiscount;
            CartInfo.Discount = Discount;
            CartInfo.TotalPrice = TotalPrice;
        }

    }
}
