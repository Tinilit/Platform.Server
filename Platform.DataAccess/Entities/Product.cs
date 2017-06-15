using System;
using System.Collections.Generic;

namespace Platform.DataAccess.Entities
{
    public class Product : Entity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Colour { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }

        public Brand Brand { get; set; }
        public ICollection<SellOffer> SellOffers { get; set; }
        public ICollection<BuyOffer> BuyOffers { get; set; }
        public ICollection<WantList> WantLists { get; set; }
    }
}
