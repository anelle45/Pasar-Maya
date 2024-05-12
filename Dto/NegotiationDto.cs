using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Dto
{
    public class NegotiationDto
    {
        public int Id { get; set; }
        public string Negotiation { get; set; }
        public string LastNegotiation { get; set; }
        public NegoStatus NegoStatus { get; set; }
        public string NegotiateById { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
