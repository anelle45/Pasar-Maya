using Pasar_Maya_Api.Dto;
using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Interfaces
{
	public interface ICommodityTypeRepository
	{
		ICollection<CommodityType> GetCommodityTypes(PaginationDto paginationDto);
		CommodityType GetCommodityType(int id);
		bool AddCommodityType(CommodityType commodityType);
		bool UpdateCommodityType(CommodityType commodityType);
		bool DeleteCommodityType(int id);
		bool Save();
	}
}
