using Pasar_Maya_Api.Dto;
using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Interfaces
{
	public interface IAreaRepository
	{
		ICollection<Area> GetAreas(PaginationDto paginationDto);
		Area GetArea(int id);
		bool AddArea(Area area);
		bool UpdateArea(Area area);
		bool DeleteArea(int id);
		bool Save();
	}
}
