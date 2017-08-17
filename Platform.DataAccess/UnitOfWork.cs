using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Platform.DataAccess.Interfaces;
using Platform.DataAccess.Repositories;

namespace Platform.DataAccess
{
    public class UnitOfWork:IUnitOfWork
    {
        private DbContext _context;

        public UnitOfWork(
            PlatformContext context,
            IBrandRepository brandRepository,
            IUserRepository userRepository,
            ITestRepository testRepository,
            ITestTypeRepository testTypeRepository)
        {
            BrandRepository = brandRepository;
            UserRepository = userRepository;
            TestRepository = testRepository;
            TestTypeRepository = testTypeRepository;
            _context = context;
        }

        public IBrandRepository BrandRepository { get; }
        public IUserRepository UserRepository { get; }
        public ITestRepository TestRepository { get; }
        public ITestTypeRepository TestTypeRepository { get; }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
