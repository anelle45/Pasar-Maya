namespace Pasar_Maya_Api.Models
{
    public class Cart
    {
        
        public int id { get; set; }
        public User user { get; set; }
        public int groupId { get; set; }
        public ICollection<CartsProducts> CartProducts { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class ProductQuantity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
