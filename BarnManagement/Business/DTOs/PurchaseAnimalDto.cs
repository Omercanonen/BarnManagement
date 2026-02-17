namespace BarnManagement.Business.DTOs
{
    public class PurchaseAnimalDto
    {
        public string AnimalName { get; set; } = null!;
        public string AnimalGender { get; set; } = null!;
        public int AnimalSpeciesId { get; set; }
        public int BarnId { get; set; }
    }
}
