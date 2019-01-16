using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using A2.Lib;

namespace A2.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class POSController : ControllerBase
    {
        public static ProductManagement _productManagement = new ProductManagement();
        public static CartManagement _cartManagement = new CartManagement();

        [HttpGet]
        public IEnumerable<Product> GetProducts() => _productManagement.Products;

        [HttpPost]
        public void CreateProduct([FromBody]Product product) => _productManagement.AddProduct(product);

        [HttpGet]
        public Cart GetCart() => _cartManagement.CartInfo;

        [HttpPost]
        public void OrderProduct([FromBody]OrderProduct product) => _cartManagement.OrderProduct(product);
    }
}
