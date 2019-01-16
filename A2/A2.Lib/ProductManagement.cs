using System;
using System.Collections.Generic;

namespace A2.Lib
{
    public class ProductManagement
    {
        public List<Product> Products { get; private set; }
        public ProductManagement() => Products = new List<Product>();

        public void AddProduct(Product product)
        {
            const double MinimumPrice = 0;
            var isDataValid = !string.IsNullOrWhiteSpace(product.Name) && product.Price > MinimumPrice;
            if (!isDataValid) return;
            Products.Add(product);
        }
    }
}
