using System.Collections.Generic;
using System.Linq;
using Platform.DataAccess.Entities;
using Platform.DataAccess.Interfaces;

namespace Platform.DataAccess.Repositories
{
    public class SellOfferRepository:ISellOfferRepository
    {
        private PlatformContext _context;

        public SellOfferRepository(PlatformContext context)
        {
            _context = context;
        }

        public void Add(SellOffer entity)
        {
            _context.Add(entity);
        }

        public void Delete(SellOffer entity)
        {
            _context.Remove(entity);
        }

        public IEnumerable<SellOffer> GetAllSellOffers()
        {
            return _context.SellOffers.ToList();
        }

        public SellOffer GetSellOffer(int id)
        {
            return _context.SellOffers.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<SellOffer> GetSellOffersByProductId(int productId)
        {
            return _context.SellOffers.Where(x => x.Product.Id == productId).ToList();
        }
    }
}
