using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Dto.BodyModels
{
    public class NegotiationsPostDto
    {
        public string Negotiation { get; set; }
        public string LastNegotiation { get; set; }
        public NegoStatus NegoStatus { get; set; }
        public string NegotiateById { get; set; }
        public int ProductId { get; set; }
    }
}
