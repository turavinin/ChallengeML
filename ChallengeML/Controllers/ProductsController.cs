using AutoMapper;
using ChallengeML.Domain.Entities.Filters;
using ChallengeML.Domain.Interfaces.Services;
using ChallengeML.DTO.Product.Filters;
using ChallengeML.DTO.Product.Response;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeML.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        [Route("api/products")]
        public async Task<IActionResult> Get([FromQuery] ProductFiltersRequest productFiltersRequest)
        {
            var filters = _mapper.Map<ProductFilters>(productFiltersRequest);
            var products = await _productService.Get(filters);

            return Ok(_mapper.Map<List<ProductResponse>>(products));
        }

        [HttpGet]
        [Route("api/products/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.Get(id);

            return Ok(_mapper.Map<ProductResponse>(product));
        }
    }
}
