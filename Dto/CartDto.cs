using Pasar_Maya_Api.Dto.BodyModels;
using Pasar_Maya_Api.Models;

public class CartDto
{
    public int Id { get; set; }
    public User? User { get; set; }
    public int GroupId { get; set; }
    public ICollection<ProductQuantityDto> ProductQuantities { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public CartDto()
    {
        User = new User();
        ProductQuantities = new List<ProductQuantityDto>();
    }
}