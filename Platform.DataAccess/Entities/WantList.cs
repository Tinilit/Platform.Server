using System;

namespace Platform.DataAccess.Entities
{
    public class WantList : Entity
    {
        public int Id { get; set; }
        public string UKSize { get; set; }
        public string EUSize { get; set; }
        public DateTime  DateTimeAdded { get; set; }

        public Product Product { get; set; }
        public User User { get; set; }
    }
}
