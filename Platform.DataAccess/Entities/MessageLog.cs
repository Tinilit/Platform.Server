namespace Platform.DataAccess.Entities
{
    public class MessageLog: Entity
    {
        public int Id { get; set; }
        public string MessageContent { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }
        public BuyOffer BuyOffer { get; set; }
        public SellOffer SellOffer { get; set; }
        public Transaction Transaction { get; set; }
    }
}
