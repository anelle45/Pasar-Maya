using Pasar_Maya_Api.Dto;
using Pasar_Maya_Api.Dto.BodyModels;
using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Interfaces
{
	public interface IDiscussionRepository
	{
		ICollection<Discussion> GetDiscussions(PaginationDto paginationDto);
		Discussion GetDiscussion(int id);
		ICollection<Discussion> GetDiscussionsByUserWhoCreated(string id, PaginationDto paginationDto);
		ICollection<DiscussionAnswer> GetPinnedAnswer(int id);
		ICollection<Image> GetDiscussionImage(int id);
		ICollection<Discussion> SearchDiscussions(string search, PaginationDto paginationDto);
		bool AddLike(int id);
		bool RemoveLike(int id);
		bool AddSolved(int id);
		bool RemoveSolved(int id);
		bool AddPinnedAnswer(int discussionId, int answerId);
		bool RemovePinnedAnswer(int discussionId, int answerId);
		bool UpdateDiscussion(Discussion discussion);
		bool AddDiscussionImage(int discussionId, List<ImagePostDto> image);
		bool RemoveDiscussionImage(int discussionId, int ImageId);
		bool CreateDiscussion(Discussion discussion);
		bool DeleteDiscussion(int id);
		bool Save();
	}
}
