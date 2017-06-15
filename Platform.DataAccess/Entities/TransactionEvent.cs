using System;

namespace Platform.DataAccess.Entities
{
    public class TransactionEvent : Entity
    {
        public int Id { get; set; }
        public string Event { get; set; }

        public Transaction Transaction { get; set; }
        public DateTime DateTime { get; set; }
    }
}
