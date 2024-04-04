using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Dto
{
	public class ProductReviewDto
	{
		public int Id { get; set; }
		public string Message { get; set; }
		public int Likes { get; set; }
		public UserDto ReviewedBy { get; set; }
		public int ProductId { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
