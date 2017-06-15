using System.Collections.Generic;

namespace Platform.DataAccess.Entities
{
    public class Brand:Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
