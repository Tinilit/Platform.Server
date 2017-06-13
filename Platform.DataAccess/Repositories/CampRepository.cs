using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Platform.DataAccess.Entities;
using Platform.DataAccess.Interfaces;

namespace Platform.DataAccess.Repositories
{
  public class CampRepository : ICampRepository
  {
    private PlatformContext _context;

    public CampRepository(PlatformContext context)
    {
      _context = context;
    }

    public void Add(Camp entity)
    {
      _context.Add(entity);
    }

    public void Delete(Camp entity)
    {
      _context.Remove(entity);
    }

    public IEnumerable<Camp> GetAllCamps()
    {
      return _context.Camps
                .Include(c => c.Location)
                .OrderBy(c => c.EventDate)
                .ToList();
    }

    public Camp GetCamp(int id)
    {
      return _context.Camps
        .Include(c => c.Location)
        .Where(c => c.Id == id)
        .FirstOrDefault();
    }

    public Camp GetCampWithSpeakers(int id)
    {
      return _context.Camps
        .Include(c => c.Location)
        .Include(c => c.Speakers)
        .ThenInclude(s => s.Talks)
        .Where(c => c.Id == id)
        .FirstOrDefault();
    }

    public Camp GetCampByMoniker(string moniker)
    {
      return _context.Camps
        .Include(c => c.Location)
        .Where(c => c.Moniker.Equals(moniker, StringComparison.CurrentCultureIgnoreCase))
        .FirstOrDefault();
    }

    public Camp GetCampByMonikerWithSpeakers(string moniker)
    {
      return _context.Camps
        .Include(c => c.Location)
        .Include(c => c.Speakers)
        .ThenInclude(s => s.Talks)
        .Where(c => c.Moniker.Equals(moniker, StringComparison.CurrentCultureIgnoreCase))
        .FirstOrDefault();
    }

    public async Task<bool> SaveAllAsync()
    {
      return (await _context.SaveChangesAsync()) > 0;
    }
  }
}
