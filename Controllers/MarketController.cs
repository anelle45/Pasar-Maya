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
    public class MarketController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ResponseHelper _responseHelper;
        private readonly IMarketsRepository _marketRepository;
        public MarketController(
            IMapper mapper,
            ResponseHelper responseHelper,
            INegotiationRepository negotiationRepository,
            IUserRepository userRepository,
            IProductRepository productRepository,
            IMarketsRepository marketsRepository,
            DataContext context,
            IMemoryCache cache
            )
        {
            _mapper = mapper;
            _responseHelper = responseHelper;
            _marketRepository = marketsRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MarketDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetMarkets()
        {
            try
            {
                var result = _mapper.Map<MarketDto>(_marketRepository.GetMarkets());
                if (!ModelState.IsValid)
                    return BadRequest(_responseHelper.Error(ModelState.Select(ex => ex.Value?.Errors).FirstOrDefault()?.Select(e => e.ErrorMessage).FirstOrDefault()?.ToString()));

                if (result == null)
                    return Ok(_responseHelper.Success("No Market found"));

                var resultMap = _mapper.Map<List<MarketDto>>(result);
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
        [HttpGet("{marketId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MarketDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetMarketById(int marketId)
        {
            try
            {
                var result = _mapper.Map<MarketDto>(_marketRepository.GetMarketById(marketId));
                if (!ModelState.IsValid)
                    return BadRequest(_responseHelper.Error(ModelState.Select(ex => ex.Value?.Errors).FirstOrDefault()?.Select(e => e.ErrorMessage).FirstOrDefault()?.ToString()));

                if (result == null)
                    return Ok(_responseHelper.Success("No Market found"));

                var resultMap = _mapper.Map<List<MarketDto>>(result);
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
        [ProducesResponseType(200, Type = typeof(IEnumerable<MarketDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetMarketsByUserId([FromQuery] string userId)
        {
            try
            {
                var result = _mapper.Map<List<MarketDto>>(_marketRepository.GetMarketsByUserId(userId));
                if (!ModelState.IsValid)
                    return BadRequest(_responseHelper.Error(ModelState.Select(ex => ex.Value?.Errors).FirstOrDefault()?.Select(e => e.ErrorMessage).FirstOrDefault()?.ToString()));

                if (result.Any() != true)
                    return Ok(_responseHelper.Success("No Negotiation found"));

                var resultMap = _mapper.Map<List<MarketDto>>(result);
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
        [HttpGet("GetUsers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MarketDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetUsersByMarket([FromQuery] int marketId)
        {
            try
            {
                var result = _mapper.Map<UserDto>(_marketRepository.GetUsersByMarket(marketId));
                if (!ModelState.IsValid)
                    return BadRequest(_responseHelper.Error(ModelState.Select(ex => ex.Value?.Errors).FirstOrDefault()?.Select(e => e.ErrorMessage).FirstOrDefault()?.ToString()));

                if (result == null)
                    return Ok(_responseHelper.Success("No User found"));

                var resultMap = _mapper.Map<List<MarketDto>>(result);
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
        public IActionResult AddMarket([FromBody] MarketPostDto marketPostDto)
        {
            try
            {
                var market = _mapper.Map<Market>(marketPostDto);
                market.CreatedAt = DateTime.Now;
                market.UpdatedAt = DateTime.Now;

                if (!ModelState.IsValid)
                    return BadRequest(_responseHelper.Error(ModelState.Select(ex => ex.Value?.Errors).FirstOrDefault()?.Select(e => e.ErrorMessage).FirstOrDefault()?.ToString()));


                if (_marketRepository.AddMarket(market))
                    throw new Exception("Something went wrong while adding product");

                return Ok(_responseHelper.Success("Market added successfully"));
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

        [HttpPut("{marketId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateMarket(int marketId, [FromBody] MarketPutDto marketPutDto)
        {
            try
            {
                var market = _mapper.Map<Market>
                    (_marketRepository.GetMarketById(marketId));
                _mapper.Map(marketPutDto, market);
                market.UpdatedAt = DateTime.Now;

                if (!ModelState.IsValid)
                    return BadRequest(_responseHelper.Error(ModelState.Select(ex => ex.Value?.Errors).FirstOrDefault()?.Select(e => e.ErrorMessage).FirstOrDefault()?.ToString()));

                if (!_marketRepository.UpdateMarket(market))
                    throw new Exception("Something went wrong while updating product");

                return Ok(_responseHelper.Success("Market updated successfully"));
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

        [HttpDelete("{marketId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult DeleteMarket(int marketId)
        {
            try
            {
                _marketRepository.DeleteMarket(marketId);
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
