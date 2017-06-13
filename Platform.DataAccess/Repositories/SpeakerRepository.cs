using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Platform.DataAccess.Entities;
using Platform.DataAccess.Interfaces;

namespace Platform.DataAccess.Repositories
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private PlatformContext _context;

        public SpeakerRepository(PlatformContext context)
        {
            _context = context;
        }
        public void Add(Speaker entity)
        {
            _context.Add(entity);
        }

        public void Delete(Speaker entity)
        {
            _context.Remove(entity);
        }

        public Speaker GetSpeaker(int speakerId)
        {
            return _context.Speakers
              .Include(s => s.Camp)
              .Where(s => s.Id == speakerId)
              .FirstOrDefault();
        }

        public IEnumerable<Speaker> GetSpeakers(int id)
        {
            return _context.Speakers
              .Include(s => s.Camp)
              .Where(s => s.Camp.Id == id)
              .OrderBy(s => s.Name)
              .ToList();
        }

        public IEnumerable<Speaker> GetSpeakersWithTalks(int id)
        {
            return _context.Speakers
              .Include(s => s.Camp)
              .Include(s => s.Talks)
              .Where(s => s.Camp.Id == id)
              .OrderBy(s => s.Name)
              .ToList();
        }

        public IEnumerable<Speaker> GetSpeakersByMoniker(string moniker)
        {
            return _context.Speakers
              .Include(s => s.Camp)
              .Where(s => s.Camp.Moniker.Equals(moniker, StringComparison.CurrentCultureIgnoreCase))
              .OrderBy(s => s.Name)
              .ToList();
        }

        public IEnumerable<Speaker> GetSpeakersByMonikerWithTalks(string moniker)
        {
            return _context.Speakers
              .Include(s => s.Camp)
              .Include(s => s.Talks)
              .Where(s => s.Camp.Moniker.Equals(moniker, StringComparison.CurrentCultureIgnoreCase))
              .OrderBy(s => s.Name)
              .ToList();
        }

        public Speaker GetSpeakerWithTalks(int speakerId)
        {
            return _context.Speakers
              .Include(s => s.Camp)
              .Include(s => s.Talks)
              .Where(s => s.Id == speakerId)
              .FirstOrDefault();
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
