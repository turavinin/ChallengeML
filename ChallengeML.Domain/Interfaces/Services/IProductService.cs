using ChallengeML.Domain.Entities;
using ChallengeML.Domain.Entities.Filters;

namespace ChallengeML.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<Product>> Get(ProductFilters filters);
        Task<Product> Get(int id);
    }
}
