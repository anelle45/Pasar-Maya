using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Dto
{
	public class NotificationDto
	{
		public int Id { get; set; }
		public string Message { get; set; }
		public UserDto User { get; set; }
		public bool IsRead { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
