using Platform.DataAccess.Entities;

namespace Platform.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        // PlatformUser
        User GetUser(string userName);
    }
}
