namespace BarnManagement.Business.DTOs
{
    public class BarnCreateDto
    {
        public string BarnName { get; set; } = null!;
        public string BarnLocation { get; set; } = null!;
        public string BarnPersonInCharge { get; set; } = null!;
        public int BarnMaxCapacity { get; set; }
        public string OwnerUserId { get; set; } = null!;
    }
}
