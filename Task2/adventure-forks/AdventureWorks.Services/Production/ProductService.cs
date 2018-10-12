using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Services.Production
{
    public class ProductService: IProductService
    {
        private readonly DbModel.Entities _entities = new DbModel.Entities();
        public IEnumerable<Product> GetProducts()
        {
            var query = from p in _entities.Products select MapProductFromDb(p);
            return query.ToArray();
        }

        public Product GetProduct(int id)
        {
            return MapProductFromDb(_entities.Products.Find(id));
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = _entities.Products.Find(product.Id);
            if (productToUpdate == null) return;
            _entities.Entry(productToUpdate).CurrentValues.SetValues(MapProductForDb(product));
            _entities.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            _entities.Products.Remove(_entities.Products.SingleOrDefault(x => x.ProductID == id) ??
                                      throw new InvalidOperationException());
            _entities.SaveChanges();
        }

        public void AddProduct(Product product)
        {
            _entities.Products.Add(MapProductForDb(product));
            _entities.SaveChanges();
        }

        private Product MapProductFromDb(DbModel.Product product)
        {
            return new Product()
            {
                Id = product.ProductID,
                Name = product.Name,
                ProductNumber = product.ProductNumber,
                MakeFlag = product.MakeFlag,
                FinishedGoodsFlag = product.FinishedGoodsFlag,
                Color = product.Color,
                SafetyStockLevel = product.SafetyStockLevel,
                ReorderPoint = product.ReorderPoint,
                StandardCost = product.StandardCost,
                ListPrice = product.ListPrice,
                Size = product.Size,
                SizeUnitMeasure = MapUnitMeasureFromDb(product.SizeUnitMeasureCode),
                WeightUnitMeasure = MapUnitMeasureFromDb(product.WeightUnitMeasureCode),
                Weight = product.Weight,
                DaysToManufacture = product.DaysToManufacture,
                ProductLine = product.ProductLine,
                Class = product.Class,
                Style = product.Style,
                ProductSubcategory = _entities.ProductSubcategories
                        .Where(x => x.ProductSubcategoryID == product.ProductSubcategoryID.Value).Select(x =>
                            new ProductSubcategory
                            {
                                Id = x.ProductSubcategoryID,
                                Name = x.Name,
                                ModifiedDate = x.ModifiedDate,
                                ProductCategory = _entities.ProductCategories
                                    .Where(y => y.ProductCategoryID == x.ProductCategoryID).Select(c =>
                                        new ProductCategory
                                        {
                                            Id = c.ProductCategoryID,
                                            ModifiedDate = c.ModifiedDate,
                                            Name = c.Name
                                        }).Single()
                            }).Single(),
                SellStartDate = product.SellStartDate,
                SellEndDate = product.SellEndDate,
                DiscontinuedDate = product.DiscontinuedDate,
                ModifiedDate = product.ModifiedDate
            };
        }

        private UnitMeasure MapUnitMeasureFromDb(string unitMeasureCode)
        {
            return _entities.UnitMeasures.Where(x => x.UnitMeasureCode == unitMeasureCode)
                .Select(x =>
                    new UnitMeasure {Code = x.UnitMeasureCode, ModifiedDate = x.ModifiedDate, Name = x.Name})
                .Single();
        }

        private DbModel.Product MapProductForDb(Product product)
        {
            return new DbModel.Product
            {
                ProductID = product.Id,
                Name = product.Name,
                ProductNumber = product.ProductNumber,
                MakeFlag = product.MakeFlag,
                FinishedGoodsFlag = product.FinishedGoodsFlag,
                Color = product.Color,
                SafetyStockLevel = product.SafetyStockLevel,
                ReorderPoint = product.ReorderPoint,
                StandardCost = product.StandardCost,
                ListPrice = product.ListPrice,
                Size = product.Size,
                SizeUnitMeasureCode = product.SizeUnitMeasure.Code,
                WeightUnitMeasureCode = product.WeightUnitMeasure.Code,
                Weight = product.Weight,
                DaysToManufacture = product.DaysToManufacture,
                ProductLine = product.ProductLine,
                Class = product.Class,
                Style = product.Style,
                ProductSubcategoryID = product.ProductSubcategory.Id,
                SellStartDate = product.SellStartDate,
                SellEndDate = product.SellEndDate,
                DiscontinuedDate = product.DiscontinuedDate,
                ModifiedDate = product.ModifiedDate
            };
        }
    }
}
