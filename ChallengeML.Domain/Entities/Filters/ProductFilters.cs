namespace ChallengeML.Domain.Entities.Filters
{
    public class ProductFilters : PaginationFilters
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
    }
}
