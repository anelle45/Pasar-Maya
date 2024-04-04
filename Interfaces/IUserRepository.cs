using Pasar_Maya_Api.Dto;
using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Interfaces
{
	public interface IUserRepository
	{
		ICollection<User> GetUsers(PaginationDto paginationDto);
		User GetUser(string id);
		ICollection<Notification> GetNotificationsByUser(string userId, PaginationDto paginationDto);
		ICollection<Area> GetAreasByUser(string userId, PaginationDto paginationDto);
		ICollection<Product> GetProductsByUser(string userId, PaginationDto paginationDto);
		ICollection<Order> GetOrdersByUser(string userId, PaginationDto paginationDto);
		bool DeleteDiscussionByUser(string userId);
		bool Save();

	}
}
