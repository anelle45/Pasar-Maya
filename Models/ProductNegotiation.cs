namespace Pasar_Maya_Api.Models
{
	public class ProductNegotiation
	{
        public int Id { get; set; }
        public string Negotiation { get; set; }
        public string LastNegotiation { get; set; }
        public NegoStatus NegoStatus { get; set; }
        public User NegotiateBy { get; set; }
        public Product Product { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public enum NegoStatus
    {
        BuyerNegotiate = 1,
        SellerNegotiate = 2,
        Accept = 3,
        CancelByBuyer = 4,
        Decline = 5,
    }
}
