using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Platform.DataAccess.Interfaces;

namespace Platform.DataAccess
{
    public class UnitOfWork:IUnitOfWork
    {
        private DbContext _context;

        public UnitOfWork(
            PlatformContext context,
            IBrandRepository brandRepository,
            IProductRepository productRepository,
            IUserRepository userRepository, IBuyOfferRepository buyOfferRepository, IMessageLogRepository messageLogRepository, ISellOfferRepository sellOfferRepository, ITransactionEventRepository transactionEventRepository, ITransactionRepository transactionRepository, IUserCommunicationRepository userCommunicationRepository, IWantListRepository wantListRepository)
        {
            BrandRepository = brandRepository;
            ProductRepository = productRepository;
            UserRepository = userRepository;
            BuyOfferRepository = buyOfferRepository;
            MessageLogRepository = messageLogRepository;
            SellOfferRepository = sellOfferRepository;
            TransactionEventRepository = transactionEventRepository;
            TransactionRepository = transactionRepository;
            UserCommunicationRepository = userCommunicationRepository;
            WantListRepository = wantListRepository;
            _context = context;
        }

        public IBrandRepository BrandRepository { get; }
        public IBuyOfferRepository BuyOfferRepository { get; }
        public IMessageLogRepository MessageLogRepository { get; }
        public ISellOfferRepository SellOfferRepository { get; }
        public ITransactionEventRepository TransactionEventRepository { get; }
        public ITransactionRepository TransactionRepository { get; }
        public IUserCommunicationRepository UserCommunicationRepository { get; }
        public IWantListRepository WantListRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IUserRepository UserRepository { get; }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
