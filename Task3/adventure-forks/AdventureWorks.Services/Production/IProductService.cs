using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Services.Production
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        void AddProduct(Product product);
    }
}
