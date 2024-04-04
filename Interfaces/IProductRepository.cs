using Pasar_Maya_Api.Dto;
using Pasar_Maya_Api.Dto.BodyModels;
using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Interfaces
{
	public interface IProductRepository
	{
		ICollection<Product> GetProducts(PaginationDto paginationDto);
		ICollection<Product> SearchProduct(string search, PaginationDto paginationDto);
		Product GetProduct(int id);
		bool AddProduct(Product product);
		bool UpdateProduct(Product product);
		bool DeleteProduct(int id);
		ICollection<Image> GetProductImages(int productId);
		ICollection<ProductReview> GetProductReviews(int productId, PaginationDto paginationDto);
		bool AddProductImage(int productId, List<ImagePostDto> image);
		bool RemoveProductImage(int productId, int ImageId);
		bool Save();
	}
}
