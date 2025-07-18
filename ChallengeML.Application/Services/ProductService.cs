using ChallengeML.Domain.Entities;
using ChallengeML.Domain.Entities.Exceptions;
using ChallengeML.Domain.Entities.Filters;
using ChallengeML.Domain.Interfaces.Repositories;
using ChallengeML.Domain.Interfaces.Services;
using System.Net;

namespace ChallengeML.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> Get(ProductFilters filters)
        {
            return await _productRepository.Get(filters);
        }

        public async Task<Product> Get(int id)
        {
            var filters = new ProductFilters { Id = id };
            var products = await _productRepository.Get(filters);

            if (products is null || products.Count == 0)
            {
                throw new FunctionalException("Product not found", HttpStatusCode.NotFound);
            }

            return products.First();
        }
    }
}
