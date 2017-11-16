using System.Collections.Generic;

namespace Platform.DataAccess.Entities
{
    public class Test : Entity
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }

        public string ProviderId { get; set; }
        public User Provider { get; set; }

        public int TestTypeId { get; set; }
        public TestType TestType { get; set; }

        public List<UserTest> UserTests { get; set; }
    }
}