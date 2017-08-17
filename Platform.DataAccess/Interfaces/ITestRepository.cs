using Platform.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.DataAccess.Interfaces
{
    public interface ITestRepository : IRepository<Test>
    {
        Test GetById(int id);
        IEnumerable<Test> Get();
    }
}
