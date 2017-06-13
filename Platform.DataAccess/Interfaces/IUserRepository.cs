using Platform.DataAccess.Entities;

namespace Platform.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        // PlatformUser
        User GetUser(string userName);
    }
}
