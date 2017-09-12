using Platform.DataAccess.Entities;
using System.Collections.Generic;

namespace Platform.DataAccess.Interfaces
{
    public interface IProfileRepository : IRepository<Profile>
    {
        IEnumerable<Profile> GetAllProfiles();
        Profile GetProfileById(int id);
        Profile GetProfileByUserName(string userName);
    }
}
