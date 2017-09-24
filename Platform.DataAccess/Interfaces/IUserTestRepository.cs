using Platform.DataAccess.Entities;
using System.Collections.Generic;

namespace Platform.DataAccess.Interfaces
{
    public interface IUserTestRepository : IRepository<UserTest>
    {
        UserTest GetUserTestById(int userTestId);
        IEnumerable<UserTest> GetAllUserTests();
    }
}
