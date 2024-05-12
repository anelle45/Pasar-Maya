using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Interfaces
{
    public interface ICartRepository
    {
        Cart GetCartById(int cartId);
        ICollection<Cart> GetCartsByUserId(string userId);
        ICollection<Cart> GetCartsByGroupId(string userId, int groupId);
        bool UpdateCart(Cart cart);
        bool AddCart(Cart cart);
        bool DeleteCart(int id);
        bool Save();
    }
}
