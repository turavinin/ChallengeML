namespace ChallengeML.DTO.Product.Filters
{
    public class ProductFiltersRequest : PaginationFiltersRequest
    {
        public string? Name { get; set; }
        public string? Category { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
