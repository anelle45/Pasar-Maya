using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pasar_Maya_Api.Data;
using Pasar_Maya_Api.Interfaces;
using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Repository
{
    public class MarketRepository : IMarketsRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MarketRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AddMarket(Market market)
        {
            _context.Markets.Add(market);
            return Save();
        }

        public bool DeleteMarket(int id)
        {
            var market = _context.Markets.Find(id);
            _context.Markets.Remove(market);
            return Save();
        }

        public Market GetMarketById(int marketId)
        {
            var market = _context.Markets
                .Include(m => m.user)
                .Where(m => m.Id == marketId)
                .FirstOrDefault();

            return market;
        }

        public ICollection<Market> GetMarkets()
        {
            return _context.Markets.Include(m => m.user).ToList();
        }

        public Market GetMarketsByUserId(string userId)
        {
            return _context.Markets
             .Where(m => m.user.Any(u => u.Id == userId))
             .FirstOrDefault();
        }

        public ICollection<User> GetUsersByMarket(int marketId)
        {
            return _context.Markets
                .Where(m => m.Id == marketId)
                .SelectMany(m => m.user)
                .ToList();
        }

        public bool UpdateMarket(Market market)
        {
            _context.Markets.Update(market);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

       
    }
}
