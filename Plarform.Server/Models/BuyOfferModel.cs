using System;

namespace Plarform.Server.Models
{
    public class BuyOfferModel
    {
        public string Url { get; set; }
        public string UKSize { get; set; }
        public string EUSize { get; set; }
        public decimal Price { get; set; }
        public DateTime DateListed { get; set; }
        public bool Live { get; set; }

        public string UserFirstName { get; set; }
        public string UserSurname { get; set; }
    }
}
