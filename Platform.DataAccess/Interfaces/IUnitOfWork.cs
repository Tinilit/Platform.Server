using System.Threading.Tasks;

namespace Platform.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IBrandRepository BrandRepository { get; }
        IBuyOfferRepository BuyOfferRepository { get; }
        IMessageLogRepository MessageLogRepository { get; }
        ISellOfferRepository SellOfferRepository { get; }
        ITransactionEventRepository TransactionEventRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        IUserCommunicationRepository UserCommunicationRepository { get; }
        IWantListRepository WantListRepository { get; }
        IUserRepository UserRepository { get; }
        Task<bool> SaveAllAsync();
    }
}
