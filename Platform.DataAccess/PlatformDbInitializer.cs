using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Platform.DataAccess.Entities;

namespace Platform.DataAccess
{
    public class PlatformDbInitializer
    {
        private PlatformContext _ctx;

        public PlatformDbInitializer(PlatformContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Seed()
        {

            if (!_ctx.Brands.Any())
            {
                // Add Data
                _ctx.AddRange(_sample);
                await _ctx.SaveChangesAsync();
            }
        }

        List<Brand> _sample = new List<Brand>()
        {
            new Brand()
            {
                Name = "Adidas",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Code = "A1",
                        Colour = "red",
                        Date = DateTime.Now,
                        ProductName = "Adidas superstar",
                        Description = "some description"
                    },
                    new Product()
                    {
                        Code = "A2",
                        Colour = "blue",
                        Date = DateTime.Now,
                        ProductName = "Adidas superstar",
                        Description = "some description"
                    }
                }
            },
            new Brand()
            {
                Name = "Nike",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Code = "A1",
                        Colour = "green",
                        Date = DateTime.Now,
                        ProductName = "Nike air max",
                        Description = "some description"
                    },
                    new Product()
                    {
                        Code = "A1",
                        Colour = "blue",
                        Date = DateTime.Now,
                        ProductName = "Nike air max",
                        Description = "some description"
                    }
                }
            },
        };
    }
}
