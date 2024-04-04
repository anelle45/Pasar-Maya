using Pasar_Maya_Api.Dto;
using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Interfaces
{
	public interface IOrderRepository
	{
		ICollection<Order> GetOrders(PaginationDto paginationDto);
		Order GetOrder(int id);
		bool AddOrder(Order order);
		bool UpdateOrder(Order order);
		bool DeleteOrder(int id);
		bool Save();
	}
}
