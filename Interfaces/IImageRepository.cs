using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Interfaces
{
	public interface IImageRepository
	{
		Image GetImage(int id);
		bool UpdateImage(Image image);
		bool Save();
    }
}
