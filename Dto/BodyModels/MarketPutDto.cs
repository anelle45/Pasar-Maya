using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Dto.BodyModels
{
    public class MarketPutDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ICollection<string> userIds{ get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
