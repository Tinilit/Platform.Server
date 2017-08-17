using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.DataAccess.Entities
{
    public class Test : Entity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProviderId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int TestType { get; set; }
    }
}
