using System.Collections.Generic;
using System.Linq;
using Platform.DataAccess.Entities;
using Platform.DataAccess.Interfaces;

namespace Platform.DataAccess.Repositories
{
    public class BuyOfferRepository: IBuyOfferRepository
    {
        private PlatformContext _context;

        public BuyOfferRepository(PlatformContext context)
        {
            _context = context;
        }

        public void Add(BuyOffer entity)
        {
            _context.Add(entity);
        }

        public void Delete(BuyOffer entity)
        {
            _context.Remove(entity);
        }

        public IEnumerable<BuyOffer> GetAllBuyOffers()
        {
            return _context.BuyOffers.ToList();
        }

        public BuyOffer GetBuyOffer(int id)
        {
            return _context.BuyOffers.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<BuyOffer> GetBuyOffersByProductId(int productId)
        {
            return _context.BuyOffers.Where(x => x.Product.Id == productId).ToList();
        }
    }
}
