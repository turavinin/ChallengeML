using ChallengeML.Domain.Entities;
using ChallengeML.Domain.Entities.Filters;

namespace ChallengeML.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> Get(ProductFilters filters);
    }
}
