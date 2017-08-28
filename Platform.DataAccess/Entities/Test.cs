using System;

namespace Platform.DataAccess.Entities
{
    public class Test : Entity
    {
        public int TestId { get; set; }
        public string UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }

        public int TestTypeId { get; set; }
        public TestType TestType { get; set; }
    }
}
