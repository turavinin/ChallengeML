namespace ChallengeML.DTO
{
    public class PaginationFiltersRequest
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string? OrderBy { get; set; }
        public bool? Descending { get; set; }
    }
}
