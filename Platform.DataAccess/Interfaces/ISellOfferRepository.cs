using System.Collections.Generic;
using Platform.DataAccess.Entities;

namespace Platform.DataAccess.Interfaces
{
    public interface ISellOfferRepository:IRepository<SellOffer>
    {
        IEnumerable<SellOffer>GetAllSellOffers();
        SellOffer GetSellOffer(int id);
        IEnumerable<SellOffer> GetSellOffersByProductId(int productId);
    }
}
