namespace Platform.DataAccess.Entities
{
    public class Transaction : Entity
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public SellOffer SellOffer { get; set; }
        public BuyOffer BuyOffer { get; set; }
        public Product Product { get; set; }
    }
}
