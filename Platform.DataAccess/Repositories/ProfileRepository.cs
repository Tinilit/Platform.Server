using System.Collections.Generic;
using Platform.DataAccess.Entities;
using Platform.DataAccess.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            _context.Profiles.Add(profile);
        }

        public void Delete(Profile profile)
        {
            _context.Profiles.Remove(profile);
        }

        public IEnumerable<Profile> GetAllProfiles()
        {
            return _context.Profiles
                .Include(x => x.User)
                .ToList();
        }

        public Profile GetProfileById(int id)
        {
            return _context.Profiles
                .Include(x=>x.User)
                .FirstOrDefault(arg => arg.ProfileId == id);
        }

        public Profile GetProfileByUserName(string userName)
        {
            return _context.Profiles
                .Include(x=>x.User)
                .FirstOrDefault(arg => arg.User.UserName == userName);
        }
    }
}
