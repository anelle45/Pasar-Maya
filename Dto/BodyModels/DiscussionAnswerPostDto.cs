using System.ComponentModel.DataAnnotations;

namespace Pasar_Maya_Api.Dto.BodyModels
{
	public class DiscussionAnswerPostDto
	{
		[Required]
		public string Message { get; set; }
		[Required]
		public string CreatedById { get; set; }
	}
}
