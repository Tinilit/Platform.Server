using Platform.DataAccess.Entities;
using System.Collections.Generic;

namespace Platform.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        // PlatformUser
        User GetUser(string userName);
        IEnumerable<User> GetAllUsers();
        User GetUserById(string userId);
        void Delete(User user);
    }
}
