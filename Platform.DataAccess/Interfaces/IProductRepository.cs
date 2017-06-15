using System.Collections.Generic;
using Platform.DataAccess.Entities;

namespace Platform.DataAccess.Interfaces
{
    public interface IProductRepository:IRepository<Product>
    {
        Product GetProduct(int ProductId);
        IEnumerable<Product> GetProducts(int brandId);
        IEnumerable<Product> GetProductsWithOffers(int brandId);
        IEnumerable<Product> GetProductsByBrandName(string brandName);
        IEnumerable<Product> GetProductsByBrandNameWithOffers(string brandName);
        Product GetProductWithOffers(int ProductId);
    }
}
