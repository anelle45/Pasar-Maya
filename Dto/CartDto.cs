using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Dto
{
    public class CartDto
    {
        public int id { get; set; }
        public User user { get; set; }
        public int groupId { get; set; }
        public ICollection<Product> products { get; set; }
        public ICollection<int> Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
