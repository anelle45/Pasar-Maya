using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Interfaces
{
    public interface INegotiationRepository
    {
        ProductNegotiation GetNegotiationsById(int negotiationId);
        ICollection<ProductNegotiation> GetNegotiationsByProductId(int productId); 
        ICollection<ProductNegotiation> GetNegotiationsByUserWhoCreated(string id);
        bool AddNegotiation(ProductNegotiation negotiation);
        bool UpdateNegotiation(ProductNegotiation negotiation);
        bool DeleteNegotiation(int id);
        bool Save();

    }
}
