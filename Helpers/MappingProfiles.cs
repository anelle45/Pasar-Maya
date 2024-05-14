using Pasar_Maya_Api.Dto;
using Pasar_Maya_Api.Dto.BodyModels;
using Pasar_Maya_Api.Models;
using AutoMapper;

namespace Pasar_Maya_Api.Helpers
{
	public class MappingProfiles : Profile
	{
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<Discussion, DiscussionDto>()
                .ForMember(dest => dest.CreatedBy, options => options.MapFrom(src => src.User));
			CreateMap<DiscussionPostDto, Discussion>();
			CreateMap<DiscussionPutDto, Discussion>();
			CreateMap<DiscussionAnswer, DiscussionAnswerDto>()
                .ForMember(dest => dest.AnsweredBy, options => options.MapFrom(src => src.AnsweredBy))
                .ForMember(dest => dest.DiscussionId, options => options.MapFrom(src => src.Discussion.Id));
			CreateMap<DiscussionAnswerPostDto, DiscussionAnswer>();
			CreateMap<DiscussionAnswerPutDto, DiscussionAnswer>();
			CreateMap<Area, AreaDto>();
            CreateMap<AreaPostDto, Area>();
            CreateMap<Image, ImageDto>();
			CreateMap<ImagePostDto, Image>();
            CreateMap<CommodityType, CommodityTypeDto>();
            CreateMap<CommodityTypePostDto, CommodityType>();
            CreateMap<Commodity, CommodityDto>();
            CreateMap<CommodityPostDto, Commodity>();
            CreateMap<CommodityPutDto, Commodity>();
            CreateMap<Prediction, PredictionDto>()
                .ForMember(dest => dest.CommodityId, options => options.MapFrom(src => src.Commodity.Id))
				.ForMember(dest => dest.AreaId, options => options.MapFrom(src => src.Area.Id));
            CreateMap<PredictionPostDto, Prediction>();
            CreateMap<Notification, NotificationDto>();
            CreateMap<NotificationPostDto, Notification>();
            CreateMap<NotificationPutDto, Notification>();
            CreateMap<NegotiationsPostDto, ProductNegotiation>();
            CreateMap<NegotiationPutDto, ProductNegotiation>();
            CreateMap<ProductNegotiation, NegotiationDto>()
              .ForMember(dest => dest.NegotiateById, options => options.MapFrom(src => src.NegotiateBy.Id))
              .ForMember(dest => dest.ProductId, options => options.MapFrom(src => src.Product.Id));

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CommodityId, options => options.MapFrom(src => src.Commodity.Id))
                .ForMember(dest => dest.AreaId, options => options.MapFrom(src => src.Area.Id))
                .ForMember(dest => dest.OwnerId, options => options.MapFrom(src => src.User.Id));
            CreateMap<ProductPostDto, Product>();
            CreateMap<ProductPutDto, Product>();


            CreateMap<Market, MarketDto>()
                .ForMember(dest => dest.UserIds, options => options.MapFrom(src => src.user.Select(u => u.Id).ToList()));
            CreateMap<MarketDto, Market>()
                .ForMember(dest => dest.user, option => option.Ignore());

            CreateMap<MarketPostDto, Market>();
            CreateMap<MarketPutDto, Market>();

            CreateMap<Cart, CartDto>()
                .ForMember(dest => dest.ProductQuantities, options => options.MapFrom(src => src.CartProducts.Select(cp => new ProductQuantityDto { ProductId = cp.ProductId, Quantity = cp.Quantity })));


            CreateMap<ProductQuantityDto, ProductQuantity>();
            CreateMap<CartPostDto, Cart>();
            CreateMap<CartPutDto, Cart>();

            CreateMap<ProductReview, ProductReviewDto>()
                .ForMember(dest => dest.ReviewedBy, options => options.MapFrom(src => src.ReviewedBy))
                .ForMember(dest => dest.ProductId, options => options.MapFrom(src => src.Product.Id));
            CreateMap<ProductReviewPostDto, ProductReview>();
            CreateMap<ProductReviewPutDto, ProductReview>();
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Buyer, options => options.MapFrom(src => src.Buyer))
                .ForMember(dest => dest.ProductId, options => options.MapFrom(src => src.Product.Id));
        }
    }
}
