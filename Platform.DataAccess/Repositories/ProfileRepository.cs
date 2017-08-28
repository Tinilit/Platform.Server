using System.Collections.Generic;
using Platform.DataAccess.Entities;
using Platform.DataAccess.Interfaces;
using System.Linq;

namespace Platform.DataAccess.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private PlatformContext _context;

        public ProfileRepository(PlatformContext context)
        {
            _context = context;
        }
        public void Add(Profile profile)
        {
            _context.Add(profile);
        }

        public void Delete(Profile profile)
        {
            _context.Remove(profile);
        }

        public IEnumerable<Profile> GetAllProfile()
        {
            return _context.Profile.ToList();
        }

        public Profile GetProfileById(int id)
        {
            return _context.Profile.FirstOrDefault(arg => arg.ProfileId == id);
        }

        public Profile GetProfileByUserName(string userName)
        {
            return _context.Profile.FirstOrDefault(arg => arg.User.UserName == userName);
        }
    }
}
