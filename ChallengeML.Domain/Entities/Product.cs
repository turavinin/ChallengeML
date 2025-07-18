namespace ChallengeML.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }
        public string Currency { get; set; } = null!;
        public int AvailableStock { get; set; }
        public string Category { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public double Rating { get; set; }
    }
}
