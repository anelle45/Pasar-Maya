using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Dto.BodyModels
{
	public class CommodityPostDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int CommodityTypeId { get; set; }
	}
}
