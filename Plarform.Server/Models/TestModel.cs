using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plarform.Server.Models
{
    public class TestModel
    {
        public string Url { get; set; }
        public string UserId { get; set; }
        public int ProviderId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int TestType { get; set; }
    }
}
