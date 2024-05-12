using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pasar_Maya_Api.Data;
using Pasar_Maya_Api.Interfaces;
using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CartRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        bool ICartRepository.AddCart(Cart cart)
        {
            _context.Carts.Add(cart);
            return Save();
        }

        bool ICartRepository.DeleteCart(int id)
        {
            var Cart = _context.Carts.Find(id);
            _context.Carts.Remove(Cart);
            return Save();
        }

        Cart? ICartRepository.GetCartById(int cartId)
        {
            var cart = _context.Carts
                .Include(c => c.CartProducts)
                    .ThenInclude(cp => cp.Product)
                .Include(c => c.user)
                .Where(c => c.id == cartId)
                .FirstOrDefault();

            return cart;
        }

        ICollection<Cart> ICartRepository.GetCartsByGroupId(string userId, int groupId)
        {
            var carts = _context.Carts
                .Include(c => c.CartProducts)
                    .ThenInclude(cp => cp.Product)
                .Include(c => c.user)
                .Where(c => c.groupId == groupId)
                .Where(c => c.user.Id == userId)
                .ToList();

            return carts;
        }

        ICollection<Cart> ICartRepository.GetCartsByUserId(string userId)
        {
            return _context.Carts
               .Include(c => c.CartProducts)
                    .ThenInclude(cp => cp.Product)
                .Include(c => c.user)
                .Where(c => c.user.Id == userId)
                .ToList();
        }

        bool ICartRepository.UpdateCart(Cart cart)
        {
            _context.Carts.Update(cart);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}
