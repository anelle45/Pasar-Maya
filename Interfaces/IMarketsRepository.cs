using Pasar_Maya_Api.Dto;
using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Interfaces
{
    public interface IMarketsRepository
    {
        Market GetMarketById(int marketId);
        ICollection<Market> GetMarkets(PaginationDto pagination);
        Market GetMarketsByUserId(string userId);
        ICollection<User> GetUsersByMarket(int marketId);
        bool UpdateMarket(Market market);
        bool AddMarket(Market market);
        bool DeleteMarket(int id);
        bool Save();
    }
}
