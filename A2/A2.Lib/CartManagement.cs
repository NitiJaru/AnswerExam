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
            const double MinimumPrice = 0;
            const int MinimumValue = 1;
            var isDataValid = product != null &&
                              !string.IsNullOrEmpty(product.Name) &&
                              product.PricePerUnit > MinimumPrice &&
                              product.Unit >= MinimumValue;
            if (!isDataValid) return;

            CartInfo.Products.Add(product);

            var TotalPriceBeforeDiscount = 0.00;
            var Discount = 0.00;
            var TotalPrice = 0.00;

            var group = CartInfo.Products.GroupBy(it => it.Name);
            foreach (var item in group)
            {
                foreach (var item_2 in item) item_2.TotalPrice = item_2.Unit * item_2.PricePerUnit;

                var discountAmount = 0;
                var units = item.Sum(it => it.Unit);
                var totalPrice = units * item.FirstOrDefault().PricePerUnit;

                TotalPriceBeforeDiscount += totalPrice;
                discountAmount = units / 4;
                Discount += item.FirstOrDefault().PricePerUnit * discountAmount;
            }
            TotalPrice = TotalPriceBeforeDiscount - Discount;

            CartInfo.TotalPriceBeforeDiscount = TotalPriceBeforeDiscount;
            CartInfo.Discount = Discount;
            CartInfo.TotalPrice = TotalPrice;
        }

    }
}
