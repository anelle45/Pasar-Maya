using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using Pasar_Maya_Api.Data;
using Pasar_Maya_Api.Dto;
using Pasar_Maya_Api.Dto.BodyModels;
using Pasar_Maya_Api.Helpers;
using Pasar_Maya_Api.Interfaces;
using Pasar_Maya_Api.Models;

namespace Pasar_Maya_Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ResponseHelper _responseHelper;
        private readonly ICartRepository _cartRepository;
        public CartController(
            IMapper mapper,
            ResponseHelper responseHelper,
            INegotiationRepository negotiationRepository,
            IUserRepository userRepository,
            IProductRepository productRepository,
            ICartRepository cartRepository,
            DataContext context,
            IMemoryCache cache
            )
        {
            _mapper = mapper;
            _responseHelper = responseHelper;
            _cartRepository = cartRepository;
        }
        [HttpGet("{cartId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CartDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCartById(int cartId)
        {
            try
            {
                var result = _mapper.Map<CartDto>(_cartRepository.GetCartById(cartId));
                if (!ModelState.IsValid)
                    return BadRequest(_responseHelper.Error(ModelState.Select(ex => ex.Value?.Errors).FirstOrDefault()?.Select(e => e.ErrorMessage).FirstOrDefault()?.ToString()));

                if (result == null)
                    return Ok(_responseHelper.Success("No Cart found"));

                var resultMap = _mapper.Map<List<CartDto>>(result);
                return Ok(_responseHelper.Success("", resultMap));
            }
            catch (SqlException ex)
            {
                return StatusCode(500, _responseHelper.Error("Something went wrong in sql execution", 500, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, _responseHelper.Error("Something went wrong", 500, ex.Message));
            }
        }

        [HttpGet("ByUserId")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CartDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCartsByUserId([FromQuery] string userId)
        {
            try
            {
                var result = _mapper.Map<List<CartDto>>(_cartRepository.GetCartsByUserId(userId));
                if (!ModelState.IsValid)
                    return BadRequest(_responseHelper.Error(ModelState.Select(ex => ex.Value?.Errors).FirstOrDefault()?.Select(e => e.ErrorMessage).FirstOrDefault()?.ToString()));

                if (result.Any() != true)
                    return Ok(_responseHelper.Success("No Negotiation found"));

                var resultMap = _mapper.Map<List<CartDto>>(result);
                return Ok(_responseHelper.Success("", resultMap));
            }
            catch (SqlException ex)
            {
                return StatusCode(500, _responseHelper.Error("Something went wrong in sql execution", 500, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, _responseHelper.Error("Something went wrong", 500, ex.Message));
            }
        }
        [HttpGet("ByGroupId/{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CartDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCartsByGroupId(string userId,[FromQuery] int groupId)
        {
            try
            {
                var result = _mapper.Map<List<CartDto>>(_cartRepository.GetCartsByGroupId(userId,groupId));
                if (!ModelState.IsValid)
                    return BadRequest(_responseHelper.Error(ModelState.Select(ex => ex.Value?.Errors).FirstOrDefault()?.Select(e => e.ErrorMessage).FirstOrDefault()?.ToString()));

                if (result.Any() != true)
                    return Ok(_responseHelper.Success("No Negotiation found"));

                var resultMap = _mapper.Map<List<CartDto>>(result);
                return Ok(_responseHelper.Success("", resultMap));
            }
            catch (SqlException ex)
            {
                return StatusCode(500, _responseHelper.Error("Something went wrong in sql execution", 500, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, _responseHelper.Error("Something went wrong", 500, ex.Message));
            }
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddCart([FromBody] CartPostDto cartPostDto)
        {
            try
            {
                var cart = _mapper.Map<Cart>(cartPostDto);
                cart.CreatedAt = DateTime.Now;
                cart.UpdatedAt = DateTime.Now;
               
                if (!ModelState.IsValid)
                    return BadRequest(_responseHelper.Error(ModelState.Select(ex => ex.Value?.Errors).FirstOrDefault()?.Select(e => e.ErrorMessage).FirstOrDefault()?.ToString()));


                if (_cartRepository.AddCart(cart))
                    throw new Exception("Something went wrong while adding product");

                return Ok(_responseHelper.Success("Cart added successfully"));
            }
            catch (SqlException ex)
            {
                return StatusCode(500, _responseHelper.Error("Something went wrong in sql execution", 500, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, _responseHelper.Error("Something went wrong", 500, ex.Message));
            }
        }

        [HttpPut("{cartId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCart(int cartId, [FromBody] CartPutDto cartPutDto)
        {
            try
            {
                var cart = _mapper.Map<Cart>
                    (_cartRepository.GetCartById(cartId));
                _mapper.Map(cartPutDto, cart);
                cart.UpdatedAt = DateTime.Now;

                if (!ModelState.IsValid)
                    return BadRequest(_responseHelper.Error(ModelState.Select(ex => ex.Value?.Errors).FirstOrDefault()?.Select(e => e.ErrorMessage).FirstOrDefault()?.ToString()));

                if (!_cartRepository.UpdateCart(cart))
                    throw new Exception("Something went wrong while updating product");

                return Ok(_responseHelper.Success("Cart updated successfully"));
            }
            catch (SqlException ex)
            {
                return StatusCode(500, _responseHelper.Error("Something went wrong in sql execution", 500, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, _responseHelper.Error("Something went wrong", 500, ex.Message));
            }
        }

        [HttpDelete("{cartId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult DeleteCart(int cartId)
        {
            try
            {
                _cartRepository.DeleteCart(cartId);
                return Ok(_responseHelper.Success("Product deleted successfully"));
            }
            catch (SqlException ex)
            {
                return StatusCode(500, _responseHelper.Error("Something went wrong in sql execution", 500, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, _responseHelper.Error("Something went wrong", 500, ex.Message));
            }
        }
    }
}
