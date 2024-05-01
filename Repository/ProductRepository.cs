using Pasar_Maya_Api.Data;
using Pasar_Maya_Api.Dto;
using Pasar_Maya_Api.Dto.BodyModels;
using Pasar_Maya_Api.Interfaces;
using Pasar_Maya_Api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Pasar_Maya_Api.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public ProductRepository(DataContext context, IMapper mapper)
        {
			_context = context;
			_mapper = mapper;
		}
        public bool AddProduct(Product product)
		{
			_context.Add(product);
			return Save();
		}

		public bool AddProductImage(int productId, List<ImagePostDto> image)
		{
			var product = _context.Products.Where(d => d.Id == productId).FirstOrDefault();
			foreach (var item in image)
			{
				var imageMap = _mapper.Map<Image>(item);
				imageMap.CreatedAt = DateTime.Now;
				imageMap.UpdatedAt = DateTime.Now;
				var productImage = new ProductImage
				{
					Product = product,
					Image = imageMap
				};
				_context.Add(productImage);
			}
			return Save();
		}

		public bool DeleteProduct(int id)
		{
			var product = _context.Products.Find(id);
			_context.Remove(product);
			return Save();
		}

		public Product GetProduct(int id)
		{
			var product = _context.Products
				.Where(p => p.Id == id)
				.Include(p => p.Commodity)
				.Include(p => p.Area)
				.FirstOrDefault();
			return _mapper.Map<Product>(product);
		}

		public ICollection<Image> GetProductImages(int productId)
		{
			var productImages = _context.ProductImages
				.Where(p => p.Product.Id == productId)
				.Select(p => p.Image)
				.ToList();
			return _mapper.Map<ICollection<Image>>(productImages);
		}

		public ICollection<ProductReview> GetProductReviews(int productId, PaginationDto paginationDto)
		{
			var productReviews = _context.ProductReviews
				.Where(p => p.Product.Id == productId)
				.Include(p => p.ReviewedBy)
				.Skip((paginationDto.PageNumber - 1) * paginationDto.PageSize)
				.Take(paginationDto.PageSize)
				.ToList();
			return _mapper.Map<ICollection<ProductReview>>(productReviews);
		}

		public ICollection<Product> GetProducts(PaginationDto paginationDto)
		{
			var products = _context.Products
				.Include(p => p.Commodity)
				.Include(p => p.Area)
				.Skip((paginationDto.PageNumber - 1) * paginationDto.PageSize)
				.Take(paginationDto.PageSize)
				.ToList();
			return _mapper.Map<ICollection<Product>>(products);
		}


		public bool RemoveProductImage(int productId, int ImageId)
		{
			var image = _context.Images.Find(ImageId);
			var productImage = _context.ProductImages
				.Where(p => p.Product.Id == productId && p.Image.Id == ImageId)
				.FirstOrDefault();
			_context.Remove(productImage);
			_context.Remove(image);
			return Save();
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public ICollection<Product> SearchProduct(string search, PaginationDto paginationDto)
		{
			var products = _context.Products
				.Where(p => p.Name.Contains(search) || p.Description.Contains(search) || p.Commodity.Name.Contains(search))
				.Include(p => p.Commodity)
				.Include(p => p.Area)
				.Skip((paginationDto.PageNumber - 1) * paginationDto.PageSize)
				.Take(paginationDto.PageSize)
				.OrderByDescending(p => p.ProductReviews.Sum(pr => pr.Likes))
				.ThenBy(p => p.Price)
				.ToList();

            return _mapper.Map<ICollection<Product>>(products);
		}
        public ICollection<Product> HeuristicKeywordSearch(string searchQuery, PaginationDto paginationDto)
        {
            // Split the search query into individual words
            var searchWords = searchQuery.Split(' ');

            // Find products where the name or description contains any of the search words
            var matchingProducts = _context.Products
                .Where(p => searchWords.Any(sw => p.Name.Contains(sw) || p.Description.Contains(sw)))
                .Include(p => p.Commodity)
                .Include(p => p.Area)
                .Skip((paginationDto.PageNumber - 1) * paginationDto.PageSize)
                .Take(paginationDto.PageSize)
                .ToList();

            // Rank the products based on a heuristic
            var rankedProducts = matchingProducts
                .Select(p => new
                {
                    Product = p,
                    Score = CalculateScore(p, searchWords)
                })
                .OrderByDescending(p => p.Score)
                .Select(p => p.Product)
                .ToList();

            return _mapper.Map<ICollection<Product>>(rankedProducts);
        }

        public double CalculateScore(Product product, string[] searchWords)
        {
            // Count how many times a word from the search query appears in the product name or description
            var matchCount = searchWords.Count(sw => product.Name.Contains(sw) || product.Description.Contains(sw));

            // Get the sum of scores from product reviews
            var sumScore = product.ProductReviews.Sum(pr => pr.Likes);

            // Consider the price in the score. You might want to normalize the price so it doesn't outweigh the other factors.
            // This is just an example, you might want to adjust the formula according to your needs.
            var normalizedPrice = 1 / (1 + product.Price);

            // Calculate the final score
            var score = matchCount + sumScore + normalizedPrice;

            return score;
        }

        public bool UpdateProduct(Product product)
		{
			_context.Update(product);
			return Save();
		}
	}
}
