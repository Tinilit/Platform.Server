using System.Collections.Generic;
using Platform.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Platform.DataAccess.Interfaces;

namespace Platform.DataAccess.Repositories
{
    public class WantListRepository:IWantListRepository
    {
        private PlatformContext _context;

        public WantListRepository(PlatformContext context)
        {
            _context = context;
        }
        public void Add(WantList entity)
        {
            _context.Add(entity);
        }

        public void Delete(WantList entity)
        {
            _context.Remove(entity);
        }

        public WantList GetWantList(int id)
        {
            return _context.WantLists
                .Include(x => x.Product)
                .Include(x=>x.User)
                .FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<WantList> GetWantLists()
        {
            return _context.WantLists
                .Include(x => x.User)
                .Include(x=>x.Product)
                .ToList();
        }

        public IEnumerable<WantList> GetWantListsByUserName(string UserName)
        {
            return _context.WantLists
                .Include(x => x.User)
                .Include(x => x.Product)
                .Where(x=>x.User.UserName == UserName)
                .ToList();
        }
    }
}
