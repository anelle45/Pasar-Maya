using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Dto
{
	public class OrderDto
	{
		public int Id { get; set; }
		public UserDto Buyer { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public string Notes { get; set; }
		public string Status { get; set; }
	}
}
