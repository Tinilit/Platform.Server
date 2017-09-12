using System.Threading.Tasks;

namespace Platform.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IBrandRepository BrandRepository { get; }
        IUserRepository UserRepository { get; }
        ITestRepository TestRepository { get; }
        ITestTypeRepository TestTypeRepository { get; }
        IProfileRepository ProfileRepository { get; }
        Task<bool> SaveAllAsync();
    }
}
