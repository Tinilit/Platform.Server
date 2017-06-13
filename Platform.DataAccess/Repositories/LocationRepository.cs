using System.Threading.Tasks;
using Platform.DataAccess.Entities;
using Platform.DataAccess.Interfaces;

namespace Platform.DataAccess.Repositories
{
    public class LocationRepository:ILocationRepository
    {
        private PlatformContext _context;

        public LocationRepository(PlatformContext context)
        {
            _context = context;
        }

        public void Add(Location entity)
        {
            _context.Add(entity);
        }

        public void Delete(Location entity)
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
