using System;
using A2.Lib;
using Xunit;

namespace A2.Test
{
    public class ProductManagementTest
    {
        [Theory(DisplayName = "Input product correct, system calcualte correct")]
        [InlineData("iPhone XS", 40000.00)]
        [InlineData("Stone", 0.09)]
        public void ProductManagementCalculate_Correct(string name, double price)
        {
            var management = new ProductManagement();
            var newProduct = new Product { Name = name, Price = price };

            management.AddProduct(newProduct);
            Assert.Single(management.Products);
        }


        [Theory(DisplayName = "Input product correct (more than one time), system calcualte correct")]
        [InlineData("iPhone XS", 40000.00)]
        public void ProductManagementCalculate_MoreThanOneTime_Correct(string name, double price)
        {
            var management = new ProductManagement();
            var newProduct = new Product { Name = name, Price = price };

            var addProductTimes = 3;
            for (int i = 0; i < addProductTimes; i++) management.AddProduct(newProduct);
            Assert.Equal(addProductTimes, management.Products.Count);
        }

        [Theory(DisplayName = "Input product incorrect, system calcualte correct")]
        [InlineData("", 40000.00)]
        [InlineData(null, 40000.00)]
        [InlineData("iPhone XS", 0)]
        public void ProductManagementCalculate_Incorrect(string name, double price)
        {
            var management = new ProductManagement();
            var newProduct = new Product { Name = name, Price = price };

            management.AddProduct(newProduct);
            Assert.Empty(management.Products);
        }
    }
}
