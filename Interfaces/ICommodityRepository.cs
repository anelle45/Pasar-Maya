using Pasar_Maya_Api.Dto;
using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Interfaces
{
	public interface ICommodityRepository
	{
		ICollection<Commodity> GetCommodities(PaginationDto paginationDto);
		Commodity GetCommodity(int id);
		ICollection<Area> GetCommodityAreas(int commodityId, PaginationDto paginationDto);
		bool AddCommodityAreaById(int commodityId, int areaId);
		bool AddCommodityArea(int commodityId, Area area);
		bool AddCommodity(Commodity commodity);
		bool UpdateCommodity(Commodity commodity);
		bool DeleteCommodity(int id);
		bool Save();
	}
}
