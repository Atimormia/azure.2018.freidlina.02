using System;
using AdventureWorks.Services.Production;
using System.Collections.Generic;
using System.Web.Http;

namespace AdventureWorks.API.Controllers
{
    public class ProductController : ApiController
    {

        // GET: api/Product
        public IEnumerable<Product> Get()
        {
            ProductService productService = new ProductService();
            return productService.GetProducts();
        }

        // GET: api/Product/5
        public Product Get(int id)
        {
            ProductService productService = new ProductService();
            return productService.GetProduct(id);
        }

        // POST: api/Product
        public void Post(Product value)
        {
            ProductService productService = new ProductService();
            productService.AddProduct(value);
        }

        // PUT: api/Product/5
        public void Put(Product value)
        {
            ProductService productService = new ProductService();
            productService.UpdateProduct(value);
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
                ProductService productService = new ProductService();
                productService.DeleteProduct(id);
        }
    }
}
