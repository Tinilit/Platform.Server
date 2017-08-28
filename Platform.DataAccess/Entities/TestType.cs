using System.Collections.Generic;

namespace Platform.DataAccess.Entities
{
    public class TestType : Entity 
    {
        public int TestTypeId { get; set; }
        public string Name { get; set; }

        public List<Test> Tests { get; set; }
    }
}
