using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Platform.DataAccess.Entities;
using Platform.DataAccess.Interfaces;

namespace Platform.DataAccess.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private PlatformContext _context;

        public BrandRepository(PlatformContext context)
        {
            _context = context;
        }

        public void Add(Brand entity)
        {
            _context.Add(entity);
        }

        public void Delete(Brand entity)
        {
            _context.Remove(entity);
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            return _context.Brands.ToList();
        }

        public Brand GetBrand(int id)
        {
            return _context.Brands.FirstOrDefault(c => c.Id == id);
        }

        public Brand GetBrandWithProducts(int id)
        {
            return _context.Brands
              .Include(c => c.Products).ThenInclude(s => s.SellOffers)
              .Include(c => c.Products).ThenInclude(s => s.BuyOffers)
              .FirstOrDefault(c => c.Id == id);
        }

        public Brand GetBrandByBrandName(string brandName)
        {
            return _context.Brands
              .FirstOrDefault(c => c.Name.Equals(brandName, StringComparison.CurrentCultureIgnoreCase));
        }

        public Brand GetBrandByBrandNameWithProducts(string brandName)
        {
            return _context.Brands
                    .Include(c => c.Products).ThenInclude(s => s.BuyOffers)
                    .Include(c => c.Products).ThenInclude(s => s.SellOffers)
              .FirstOrDefault(c => c.Name.Equals(brandName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
