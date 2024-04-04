using Pasar_Maya_Api.Dto;
using Pasar_Maya_Api.Dto.BodyModels;
using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Interfaces
{
	public interface INotificationRepository
	{
		ICollection<Notification> GetNotifications(PaginationDto paginationDto);
		Notification GetNotification(int id);
		bool AddNotification(Notification notification);
		bool UpdateNotification(Notification notification);
		bool DeleteNotification(int id);
		ICollection<Image> GetNotificationImages(int notificationId);
		bool AddNotificationImage(int notificationId, List<ImagePostDto> image);
		bool RemoveNotificationImage(int notificationId, int ImageId);
		bool Save();
	}
}
