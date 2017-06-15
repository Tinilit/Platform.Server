using System.Collections.Generic;
using Platform.DataAccess.Entities;

namespace Platform.DataAccess.Interfaces
{
    public interface IBuyOfferRepository:IRepository<BuyOffer>
    {
        IEnumerable<BuyOffer> GetAllBuyOffers();
        BuyOffer GetBuyOffer(int id);
        IEnumerable<BuyOffer> GetBuyOffersByProductId(int productId);
    }
}
