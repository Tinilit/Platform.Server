using System;

namespace Platform.DataAccess.Entities
{
    public class SellOffer : Entity
    {
        public int Id { get; set; }
        public string UKSize { get; set; }
        public string EUSize { get; set; }
        public decimal Price { get; set; }
        public DateTime DateListed { get; set; }
        public bool Live { get; set; }

        public Product Product { get; set; }
        public User User { get; set; }
    }
}
