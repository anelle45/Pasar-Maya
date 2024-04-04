using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Dto.BodyModels
{
	public class NotificationPostDto
	{
		public string Message { get; set; }
		public string UserId { get; set; }
		public bool IsRead { get; set; }
	}
}
