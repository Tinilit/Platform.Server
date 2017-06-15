using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Platform.DataAccess.Entities;
using System.Linq;
using Platform.DataAccess.Interfaces;

namespace Platform.DataAccess.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private PlatformContext _context;

        public ProductRepository(PlatformContext context)
        {
            _context = context;
        }
        public void Add(Product entity)
        {
            _context.Add(entity);
        }

        public void Delete(Product entity)
        {
            _context.Remove(entity);
        }

        public Product GetProduct(int ProductId)
        {
            return _context.Products
              .Include(s => s.Brand)
              .FirstOrDefault(s => s.Id == ProductId);
        }

        public IEnumerable<Product> GetProducts(int brandId)
        {
            return _context.Products
              .Include(s => s.Brand)
              .Where(s => s.Brand.Id == brandId)
              .OrderBy(s => s.ProductName)
              .ToList();
        }

        public IEnumerable<Product> GetProductsWithOffers(int brandId)
        {
            return _context.Products
              .Include(s => s.Brand)
              .Include(s => s.SellOffers)
              .Include(s=>s.BuyOffers)
              .Where(s => s.Brand.Id == brandId)
              .OrderBy(s => s.ProductName)
              .ToList();
        }

        public IEnumerable<Product> GetProductsByBrandName(string brandName)
        {
            return _context.Products
              .Include(s => s.Brand)
              .Where(s => s.Brand.Name.Equals(brandName, StringComparison.CurrentCultureIgnoreCase))
              .OrderBy(s => s.ProductName)
              .ToList();
        }

        public IEnumerable<Product> GetProductsByBrandNameWithOffers(string brandName)
        {
            return _context.Products
              .Include(s => s.Brand)
              .Include(s => s.SellOffers)
              .Include(s => s.BuyOffers)
              .Where(s => s.Brand.Name.Equals(brandName, StringComparison.CurrentCultureIgnoreCase))
              .OrderBy(s => s.ProductName)
              .ToList();
        }

        public Product GetProductWithOffers(int ProductId)
        {
            return _context.Products
              .Include(s => s.Brand)
              .Include(s=>s.SellOffers)
              .Include(s => s.BuyOffers)
              .FirstOrDefault(s => s.Id == ProductId);
        }
    }
}
