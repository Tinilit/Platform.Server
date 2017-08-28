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
                Name = "Adidas"
            },
            new Brand()
            {
                Name = "Nike"
            },
        };
    }
}
