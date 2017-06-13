using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Platform.DataAccess.Entities;
using Platform.DataAccess.Interfaces;

namespace Platform.DataAccess.Repositories
{
    public class TalkRepository : ITalkRepository
    {
        private PlatformContext _context;

        public TalkRepository(PlatformContext context)
        {
            _context = context;
        }

        public void Add(Talk entity)
        {
            _context.Add(entity);
        }

        public void Delete(Talk entity)
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public Talk GetTalk(int talkId)
        {
            return _context.Talks
              .Include(t => t.Speaker)
              .ThenInclude(s => s.Camp)
              .Where(t => t.Id == talkId)
              .OrderBy(t => t.Title)
              .FirstOrDefault();
        }

        public IEnumerable<Talk> GetTalks(int speakerId)
        {
            return _context.Talks
              .Include(t => t.Speaker)
              .ThenInclude(s => s.Camp)
              .Where(t => t.Speaker.Id == speakerId)
              .OrderBy(t => t.Title)
              .ToList();
        }
    }
}
