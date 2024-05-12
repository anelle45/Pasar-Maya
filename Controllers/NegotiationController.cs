using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using Pasar_Maya_Api.Data;
using Pasar_Maya_Api.Dto;
using Pasar_Maya_Api.Dto.BodyModels;
using Pasar_Maya_Api.Helpers;
using Pasar_Maya_Api.Interfaces;
using Pasar_Maya_Api.Models;
using Pasar_Maya_Api.Repository;

namespace Pasar_Maya_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegotiationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly ResponseHelper _responseHelper;
        private readonly INegotiationRepository _negotiationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly DataContext _context;
        private readonly LocalData localData;
        public NegotiationController(
            IMapper mapper,
            ResponseHelper responseHelper,
            INegotiationRepository negotiationRepository,
            IUserRepository userRepository,
            IProductRepository productRepository,
            DataContext context,
            IMemoryCache cache
            )
        {
            _mapper = mapper;
            _responseHelper = responseHelper;
            _userRepository = userRepository;
            _negotiationRepository = negotiationRepository;
            _productRepository = productRepository;
            _context = context;
            _memoryCache = cache;
            localData = new LocalData(_context, _mapper, _memoryCache);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NegotiationDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetNegotiationsFromProduct([FromQuery] int productId)
        {
            try
            {
                var result = _mapper.Map<List<NegotiationDto>>(_negotiationRepository.GetNegotiationsByProductId(productId));
                if (!ModelState.IsValid)
                    return BadRequest(_responseHelper.Error(ModelState.Select(ex => ex.Value?.Errors).FirstOrDefault()?.Select(e => e.ErrorMessage).FirstOrDefault()?.ToString()));

                if (result.Any() != true)
                    return Ok(_responseHelper.Success("No Negotiation found"));

                var resultMap = _mapper.Map<List<NegotiationDto>>(result);
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

        [HttpGet("user")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NegotiationDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetNegotiationByUserId([FromQuery] string userId)
        {
            try
            {
                var result = _mapper.Map<List<NegotiationDto>>(_negotiationRepository.GetNegotiationsByUserWhoCreated(userId));
                if (!ModelState.IsValid)
                    return BadRequest(_responseHelper.Error(ModelState.Select(ex => ex.Value?.Errors).FirstOrDefault()?.Select(e => e.ErrorMessage).FirstOrDefault()?.ToString()));

                if (result.Any() != true)
                    return Ok(_responseHelper.Success("No Negotiation found"));

                var resultMap = _mapper.Map<List<NegotiationDto>>(result);
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
        public IActionResult AddNegotiation([FromBody] NegotiationsPostDto negotiationsPostDto)
        {
            try
            {
                var negotiation = _mapper.Map<ProductNegotiation>(negotiationsPostDto);
                negotiation.NegotiateBy = _userRepository.GetUser(negotiationsPostDto.NegotiateById);
                negotiation.Product = _productRepository.GetProduct(negotiationsPostDto.ProductId);
                negotiation.CreatedAt = DateTime.Now;
                negotiation.UpdatedAt = DateTime.Now;

                if (!ModelState.IsValid)
                    return BadRequest(_responseHelper.Error(ModelState.Select(ex => ex.Value?.Errors).FirstOrDefault()?.Select(e => e.ErrorMessage).FirstOrDefault()?.ToString()));

     
                if (!_negotiationRepository.AddNegotiation(negotiation))
                    throw new Exception("Something went wrong while adding product");

                return Ok(_responseHelper.Success("Negotation added successfully"));
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

        [HttpPut("{negotiationId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateNegotiation(int negotiationId, [FromBody] NegotiationPutDto negotiationPutDto)
        {
            try
            {
                var negotiation = _mapper.Map<ProductNegotiation>
                    (_negotiationRepository.GetNegotiationsById(negotiationId));
                _mapper.Map(negotiationPutDto, negotiation);
                negotiation.UpdatedAt = DateTime.Now;

                if (!ModelState.IsValid)
                    return BadRequest(_responseHelper.Error(ModelState.Select(ex => ex.Value?.Errors).FirstOrDefault()?.Select(e => e.ErrorMessage).FirstOrDefault()?.ToString()));

            

                if (!_negotiationRepository.UpdateNegotiation(negotiation))
                    throw new Exception("Something went wrong while updating product");

                return Ok(_responseHelper.Success("Negotiation updated successfully"));
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

        [HttpDelete("{negotiationId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult DeleteNegotiaion(int negotiationId)
        {
            try
            {
                _negotiationRepository.DeleteNegotiation(negotiationId);
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
