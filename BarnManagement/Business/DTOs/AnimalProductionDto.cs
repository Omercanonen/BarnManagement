namespace BarnManagement.Business.DTOs
{
    public class AnimalProductionDto
    {
        public string SpeciesName { get; set; } = null!;
        public int Count { get; set; }
        public string ProductName { get; set; } = null!;
        public int ProductId { get; set; }
    }

    public class AccumulatedProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int TotalQuantity { get; set; }
    }
}
