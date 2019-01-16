using System;
using A2.Lib;
using Xunit;
using System.Linq;

namespace A2.Test
{
    public class CartManagementTest
    {

        [Theory(DisplayName = "Input order-product correct(no promotion), system calcualte correct")]
        [InlineData("iPhone XS", 40000.00)]
        [InlineData("Stone", 0.09)]
        public void CartManagementCalculate_NoPromotion_Correct(string name, double price)
        {
            var productManagement = new ProductManagement();
            var newProduct = new Product { Name = name, Price = price };

            productManagement.AddProduct(newProduct);
            Assert.Single(productManagement.Products);

            var cartManagement = new CartManagement();
            var orderUnit = 3;
            cartManagement.OrderProduct(new OrderProduct
            {
                Name = name,
                PricePerUnit = price,
                Unit = orderUnit
            });

            Assert.Single(cartManagement.CartInfo.Products);

            var expectedTotalPriceBeforeDiscount = price * orderUnit;
            Assert.Equal(expectedTotalPriceBeforeDiscount, cartManagement.CartInfo.Products.FirstOrDefault().TotalPrice);
            Assert.Equal(expectedTotalPriceBeforeDiscount, cartManagement.CartInfo.TotalPriceBeforeDiscount);

            var expectedDiscount = 0;
            Assert.Equal(expectedDiscount, cartManagement.CartInfo.Discount);

            var expectedTotalPrice = price * orderUnit;
            Assert.Equal(expectedTotalPrice, cartManagement.CartInfo.TotalPrice);
        }

        [Theory(DisplayName = "Input order-product correct(promotion 1 time), system calcualte correct")]
        [InlineData("iPhone XS", 40000.00)]
        [InlineData("Stone", 0.09)]
        public void CartManagementCalculate_Promotion1Time_Correct(string name, double price)
        {
            var productManagement = new ProductManagement();
            var newProduct = new Product { Name = name, Price = price };

            productManagement.AddProduct(newProduct);
            Assert.Single(productManagement.Products);

            var cartManagement = new CartManagement();
            var orderUnit = 4;
            cartManagement.OrderProduct(new OrderProduct
            {
                Name = name,
                PricePerUnit = price,
                Unit = orderUnit
            });

            Assert.Single(cartManagement.CartInfo.Products);

            var expectedTotalPriceBeforeDiscount = price * orderUnit;
            Assert.Equal(expectedTotalPriceBeforeDiscount, cartManagement.CartInfo.Products.FirstOrDefault().TotalPrice);
            Assert.Equal(expectedTotalPriceBeforeDiscount, cartManagement.CartInfo.TotalPriceBeforeDiscount);

            var expectedDiscount = price;
            Assert.Equal(expectedDiscount, cartManagement.CartInfo.Discount);

            var expectedTotalPrice = price * (orderUnit - 1);
            Assert.Equal(expectedTotalPrice, cartManagement.CartInfo.TotalPrice);
        }


        [Theory(DisplayName = "Input order-product correct(promotion 2 times), system calcualte correct")]
        [InlineData("iPhone XS", 40000.00)]
        [InlineData("Stone", 0.09)]
        public void CartManagementCalculate_Promotion2Times_Correct(string name, double price)
        {
            var productManagement = new ProductManagement();
            var newProduct = new Product { Name = name, Price = price };

            productManagement.AddProduct(newProduct);
            Assert.Single(productManagement.Products);

            var cartManagement = new CartManagement();
            var orderUnit = 8;
            cartManagement.OrderProduct(new OrderProduct
            {
                Name = name,
                PricePerUnit = price,
                Unit = orderUnit
            });

            Assert.Single(cartManagement.CartInfo.Products);

            var expectedTotalPriceBeforeDiscount = price * orderUnit;
            Assert.Equal(expectedTotalPriceBeforeDiscount, cartManagement.CartInfo.Products.FirstOrDefault().TotalPrice);
            Assert.Equal(expectedTotalPriceBeforeDiscount, cartManagement.CartInfo.TotalPriceBeforeDiscount);

            var expectedDiscount = price * (orderUnit / 4);
            Assert.Equal(expectedDiscount, cartManagement.CartInfo.Discount);

            var expectedTotalPrice = expectedTotalPriceBeforeDiscount - expectedDiscount;
            Assert.Equal(expectedTotalPrice, cartManagement.CartInfo.TotalPrice);
        }
    }
}
