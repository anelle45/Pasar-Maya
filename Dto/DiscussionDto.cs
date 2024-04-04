using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Dto
{
	public class DiscussionDto
	{
		public int Id { get; set; }
        public string Tittle { get; set; }
        public string Message { get; set; }
		public int Likes { get; set; }
		public UserDto CreatedBy { get; set; }
		public bool IsSolved { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
