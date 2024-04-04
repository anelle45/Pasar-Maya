using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Dto
{
	public class CommodityDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public CommodityType CommodityType { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
