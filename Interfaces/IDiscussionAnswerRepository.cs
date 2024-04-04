using Pasar_Maya_Api.Dto;
using Pasar_Maya_Api.Dto.BodyModels;
using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Interfaces
{
	public interface IDiscussionAnswerRepository
	{
		ICollection<DiscussionAnswer> GetDiscussionAnswers(PaginationDto paginationDto);
		DiscussionAnswer GetDiscussionAnswer(int id);
		ICollection<Image> GetDiscussionAnswerImages(int id);
		ICollection<DiscussionAnswer> GetDiscussionAnswersByDiscussionId(int id, PaginationDto paginationDto);
		bool AddDiscussionAnswer(DiscussionAnswer discussionAnswer);
		bool UpdateDiscussionAnswer(DiscussionAnswer discussionAnswer);
		bool DeleteDiscussionAnswer(int id);
		bool AddDiscussionAnswerLike(int id);
		bool RemoveDiscussionAnswerLike(int id);
		bool AddDiscussionAnswerImage(int discussionAnswerId, List<ImagePostDto> image);
		bool RemoveDiscussionAnswerImage(int discussionAnswerId, int ImageId);
		bool Save();
	}
}
