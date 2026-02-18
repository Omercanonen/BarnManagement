namespace BarnManagement.Business.DTOs
{
    public class SaleExportDto
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public int BarnId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int SaleQuantity { get; set; }
        public decimal UnitPriceAtSale { get; set; }
        public decimal SaleAmount { get; set; }
        public bool IsActive { get; set; }
        public string? SoldByUserId { get; set; }
    }
}
