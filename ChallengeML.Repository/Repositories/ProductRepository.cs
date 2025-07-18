using ChallengeML.Domain.Entities;
using ChallengeML.Domain.Entities.Filters;
using ChallengeML.Domain.Interfaces.Repositories;
using System.Text.Json;

namespace ChallengeML.Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _dataFilePath;

        public ProductRepository()
        {
            _dataFilePath = Path.Combine(AppContext.BaseDirectory, "products.json");
        }

        public async Task<List<Product>> Get(ProductFilters filters)
        {
            if (!File.Exists(_dataFilePath)) return [];

            var json = await File.ReadAllTextAsync(_dataFilePath);
            var products = JsonSerializer.Deserialize<List<Product>>(json) ?? [];

            return ApplyFilters(products, filters);
        }

        private List<Product> ApplyFilters(List<Product> products, ProductFilters filters)
        {
            if (filters == null) return products;

            var query = products.AsQueryable();

            if (filters.Id.HasValue)
                query = query.Where(p => p.Id == filters.Id);

            if (!string.IsNullOrWhiteSpace(filters.Name))
                query = query.Where(p => p.Name.Contains(filters.Name, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(filters.Category))
                query = query.Where(p => p.Category.Equals(filters.Category, StringComparison.OrdinalIgnoreCase));

            if (filters.MinPrice.HasValue)
                query = query.Where(p => p.Price >= filters.MinPrice.Value);

            if (filters.MaxPrice.HasValue)
                query = query.Where(p => p.Price <= filters.MaxPrice.Value);

            if (!string.IsNullOrWhiteSpace(filters.OrderBy))
            {
                query = filters.OrderBy.ToLower() switch
                {
                    "name" => filters.Descending == true ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name),
                    "price" => filters.Descending == true ? query.OrderByDescending(p => p.Price) : query.OrderBy(p => p.Price),
                    "category" => filters.Descending == true ? query.OrderByDescending(p => p.Category) : query.OrderBy(p => p.Category),
                    _ => query
                };
            }

            if (filters.Offset.HasValue)
                query = query.Skip(filters.Offset.Value);

            if (filters.Limit.HasValue)
                query = query.Take(filters.Limit.Value);

            return [.. query];
        }
    }
}
