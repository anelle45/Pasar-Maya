using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pasar_Maya_Api.Data;
using Pasar_Maya_Api.Interfaces;
using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Repository
{
    public class NegotiationRepository: INegotiationRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public NegotiationRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ICollection<ProductNegotiation> GetNegotiationsByProductId(int productId)
        {
            var negotation =  _context.ProductNegotiations
                .Include(n => n.Product)
                .Include(n => n.NegotiateBy)
                .Where(n => n.Product.Id == productId)
                .ToList();

            return negotation;
        }
        ProductNegotiation INegotiationRepository.GetNegotiationsById(int negotiationId)
        {
            var negotation = _context.ProductNegotiations
                 .Include(n => n.Product)
                .Include(n => n.NegotiateBy)
                .Where(n => n.Id == negotiationId)
                .FirstOrDefault();

            return negotation;
        }
        public ICollection<ProductNegotiation> GetNegotiationsByUserWhoCreated(string id)
        {
            return _context.ProductNegotiations
                .Include(n => n.NegotiateBy)
                .Include(n => n.Product)
                .Where(n => n.NegotiateBy.Id == id)
                .ToList();
        }
        public bool AddNegotiation(ProductNegotiation negotiation)
        {
            _context.ProductNegotiations.Add(negotiation);
            return Save();
        }
        public bool UpdateNegotiation(ProductNegotiation negotiation)
        {
            _context.ProductNegotiations.Update(negotiation);
            return Save();
        }
        public bool DeleteNegotiation(int id)
        {
            var negotiation = _context.ProductNegotiations.Find(id);
            _context.ProductNegotiations.Remove(negotiation);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

       
    }
}
