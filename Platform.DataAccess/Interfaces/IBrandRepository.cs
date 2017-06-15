using System.Collections.Generic;
using Platform.DataAccess.Entities;

namespace Platform.DataAccess.Interfaces
{
    public interface IBrandRepository:IRepository<Brand>
    {
        IEnumerable<Brand> GetAllBrands();
        Brand GetBrand(int id);
        Brand GetBrandWithProducts(int id);
        Brand GetBrandByBrandName(string brandName);
        Brand GetBrandByBrandNameWithProducts(string brandName);
    }
}
