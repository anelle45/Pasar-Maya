using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Dto.BodyModels
{
    public class NegotiationPutDto
    {
        public string Negotiation { get; set; }
        public string LastNegotiation { get; set; }
        public NegoStatus NegoStatus { get; set; }
    }
}
