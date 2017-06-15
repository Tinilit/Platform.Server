using System.Collections.Generic;
using Platform.DataAccess.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Platform.DataAccess.Interfaces;

namespace Platform.DataAccess.Repositories
{
    public class UserCommunicationRepository:IUserCommunicationRepository
    {
        private PlatformContext _context;

        public UserCommunicationRepository(PlatformContext context)
        {
            _context = context;
        }
        public void Add(UserCommunication entity)
        {
            _context.Add(entity);
        }

        public void Delete(UserCommunication entity)
        {
            _context.Remove(entity);
        }

        public UserCommunication GetUserCommunication(int id)
        {
            return _context.UserCommunications
                .Include(x => x.User)
                .FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<UserCommunication> GetUserCommunications()
        {
            return _context.UserCommunications
                .Include(x => x.User)
                .ToList();
        }
    }
}
