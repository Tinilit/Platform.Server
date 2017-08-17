using Platform.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.DataAccess.Interfaces
{
    public interface ITestTypeRepository : IRepository<TestType>
    {
        void Put(TestType test);
        TestType GetById(int id);
        IEnumerable<TestType> Get();
    }
}
