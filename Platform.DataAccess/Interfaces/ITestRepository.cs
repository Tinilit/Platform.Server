using Platform.DataAccess.Entities;
using System.Collections.Generic;

namespace Platform.DataAccess.Interfaces
{
    public interface ITestRepository : IRepository<Test>
    {
        Test GetById(int id);
        IEnumerable<Test> Get();
    }
}
