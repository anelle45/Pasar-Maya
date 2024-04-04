using Pasar_Maya_Api.Dto;
using Pasar_Maya_Api.Dto.BodyModels;
using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Interfaces
{
	public interface IProductReviewRepository
	{
		ICollection<ProductReview> GetProductReviews(PaginationDto paginationDto);
		ProductReview GetProductReview(int id);
		bool AddProductReview(ProductReview productReview);
		bool UpdateProductReview(ProductReview productReview);
		bool DeleteProductReview(int id);
		ICollection<Image> GetProductReviewImages(int productReviewId);
		bool AddProductReviewImage(int productReviewId, List<ImagePostDto> image);
		bool RemoveProductReviewImage(int productReviewId, int imageId);
		bool Save();
		bool AddLike(int id);
		bool RemoveLike(int id);
	}
}
