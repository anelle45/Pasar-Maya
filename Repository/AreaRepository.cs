using Pasar_Maya_Api.Data;
using Pasar_Maya_Api.Dto;
using Pasar_Maya_Api.Interfaces;
using Pasar_Maya_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Pasar_Maya_Api.Repository
{
	public class AreaRepository : IAreaRepository
	{
		private readonly DataContext _context;

		public AreaRepository(DataContext context)
        {
			_context = context;
		}

		public bool AddArea(Area area)
		{
			_context.Add(area);
			return Save();
		}

		public bool DeleteArea(int id)
		{
			var area = _context.Areas.Find(id);
			_context.Remove(area);
			return Save();
		}

		public Area GetArea(int id)
		{
			return _context.Areas.Where(a => a.Id == id).FirstOrDefault();
		}

		public ICollection<Area> GetAreas(PaginationDto paginationDto)
		{
			return _context.Areas
				.Skip((paginationDto.PageNumber - 1) * paginationDto.PageSize)
				.Take(paginationDto.PageSize)
				.ToList();
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool UpdateArea(Area area)
		{
			_context.Update(area);
			return Save();
		}
	}
}
