using Pasar_Maya_Api.Data;
using Pasar_Maya_Api.Interfaces;
using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Repository
{
	public class ImageRepository : IImageRepository
	{
		private readonly DataContext _context;

		public ImageRepository(DataContext context)
        {
			_context = context;
		}
        public Image GetImage(int id)
		{
			return _context.Images.Find(id);
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool UpdateImage(Image image)
		{
			_context.Update(image);
			return Save();
			throw new NotImplementedException();
		}
	}
}
