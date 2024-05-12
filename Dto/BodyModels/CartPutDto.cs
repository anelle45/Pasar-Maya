using System;
using System.Collections.Generic;

namespace Pasar_Maya_Api.Dto.BodyModels
{
    public class CartPutDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int GroupId { get; set; }
        public ICollection<ProductQuantityDto> ProductQuantities { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

