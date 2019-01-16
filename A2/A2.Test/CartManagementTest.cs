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

        [Fact(DisplayName = "Input mutiple order-product correct(no promotion), system calcualte correct")]
        public void CartManagementCalculate_MutipleTimes_NoPromotion_Correct()
        {
            var cartManagement = new CartManagement();
            cartManagement.OrderProduct(new OrderProduct
            {
                Name = "iPhone XS",
                PricePerUnit = 40000.00,
                Unit = 3
            });

            cartManagement.OrderProduct(new OrderProduct
            {
                Name = "Stone",
                PricePerUnit = 0.09,
                Unit = 3
            });
            Assert.NotEmpty(cartManagement.CartInfo.Products);

            var expectedTotalPriceBeforeDiscount = 120000.27;
            Assert.Equal(expectedTotalPriceBeforeDiscount, cartManagement.CartInfo.TotalPriceBeforeDiscount);

            var expectedDiscount = 0;
            Assert.Equal(expectedDiscount, cartManagement.CartInfo.Discount);

            var expectedTotalPrice = 120000.27;
            Assert.Equal(expectedTotalPrice, cartManagement.CartInfo.TotalPrice);
        }

        [Fact(DisplayName = "Input mutiple order-product correct(promotion 1 time), system calcualte correct")]
        public void CartManagementCalculate_MutipleTimes_Promotion1Time_Correct()
        {
            var cartManagement = new CartManagement();
            cartManagement.OrderProduct(new OrderProduct
            {
                Name = "iPhone XS",
                PricePerUnit = 40000.00,
                Unit = 4
            });

            cartManagement.OrderProduct(new OrderProduct
            {
                Name = "Stone",
                PricePerUnit = 1,
                Unit = 3
            });
            Assert.NotEmpty(cartManagement.CartInfo.Products);

            var expectedTotalPriceBeforeDiscount = 160003;
            Assert.Equal(expectedTotalPriceBeforeDiscount, cartManagement.CartInfo.TotalPriceBeforeDiscount);

            var expectedDiscount = 40000;
            Assert.Equal(expectedDiscount, cartManagement.CartInfo.Discount);

            var expectedTotalPrice = 120003;
            Assert.Equal(expectedTotalPrice, cartManagement.CartInfo.TotalPrice);
        }

        [Fact(DisplayName = "Input mutiple order-product correct(promotion 2 times), system calcualte correct")]
        public void CartManagementCalculate_MutipleTimes_Promotion2Time_Correct()
        {
            var cartManagement = new CartManagement();
            cartManagement.OrderProduct(new OrderProduct
            {
                Name = "iPhone XS",
                PricePerUnit = 40000.00,
                Unit = 4
            });

            cartManagement.OrderProduct(new OrderProduct
            {
                Name = "Stone",
                PricePerUnit = 1,
                Unit = 3
            });

            cartManagement.OrderProduct(new OrderProduct
            {
                Name = "iPhone XS",
                PricePerUnit = 40000.00,
                Unit = 4
            });
            Assert.NotEmpty(cartManagement.CartInfo.Products);

            var expectedTotalPriceBeforeDiscount = 320003;
            Assert.Equal(expectedTotalPriceBeforeDiscount, cartManagement.CartInfo.TotalPriceBeforeDiscount);

            var expectedDiscount = 80000;
            Assert.Equal(expectedDiscount, cartManagement.CartInfo.Discount);

            var expectedTotalPrice = 240003;
            Assert.Equal(expectedTotalPrice, cartManagement.CartInfo.TotalPrice);
        }

        [Fact(DisplayName = "Input mutiple order-product correct(promotion 1 time by 4 orders), system calcualte correct")]
        public void CartManagementCalculate_MutipleTimes_Promotion1TimeBy4Order_Correct()
        {
            var cartManagement = new CartManagement();
            cartManagement.OrderProduct(new OrderProduct
            {
                Name = "iPhone XS",
                PricePerUnit = 40000.00,
                Unit = 1
            });
            cartManagement.OrderProduct(new OrderProduct
            {
                Name = "iPhone XS",
                PricePerUnit = 40000.00,
                Unit = 1
            });
            cartManagement.OrderProduct(new OrderProduct
            {
                Name = "iPhone XS",
                PricePerUnit = 40000.00,
                Unit = 1
            });
            cartManagement.OrderProduct(new OrderProduct
            {
                Name = "Stone",
                PricePerUnit = 1,
                Unit = 3
            });
            cartManagement.OrderProduct(new OrderProduct
            {
                Name = "iPhone XS",
                PricePerUnit = 40000.00,
                Unit = 1
            });
            Assert.NotEmpty(cartManagement.CartInfo.Products);

            var expectedTotalPriceBeforeDiscount = 160003;
            Assert.Equal(expectedTotalPriceBeforeDiscount, cartManagement.CartInfo.TotalPriceBeforeDiscount);

            var expectedDiscount = 40000;
            Assert.Equal(expectedDiscount, cartManagement.CartInfo.Discount);

            var expectedTotalPrice = 120003;
            Assert.Equal(expectedTotalPrice, cartManagement.CartInfo.TotalPrice);
        }

        [Theory(DisplayName = "Input order-product incorrect, system calcualte correct")]
        [InlineData("", 40000.00)]
        [InlineData(null, 40000.00)]
        [InlineData("iPhone XS", 0)]
        [InlineData("iPhone XS", -1)]
        public void CartManagementCalculate_Incorrect(string name, double price)
        {
            var cartManagement = new CartManagement();
            var orderUnit = 3;
            cartManagement.OrderProduct(new OrderProduct
            {
                Name = name,
                PricePerUnit = price,
                Unit = orderUnit
            });

            var expectedZeroValue = 0;
            Assert.Empty(cartManagement.CartInfo.Products);
            Assert.Equal(expectedZeroValue, cartManagement.CartInfo.TotalPriceBeforeDiscount);
            Assert.Equal(expectedZeroValue, cartManagement.CartInfo.Discount);
            Assert.Equal(expectedZeroValue, cartManagement.CartInfo.TotalPrice);
        }

    }
}
