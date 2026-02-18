namespace BarnManagement.Business.DTOs
{
    public class InventoryItemDto
    {
        public int BarnInventoryId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class SellPreviewDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int StockQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int MaxSellQuantity => StockQuantity;

        public decimal TotalPrice(int sellQty) => UnitPrice * sellQty;
    }

    public class SellRequestDto
    {
        public int BarnId { get; set; }
        public int ProductId { get; set; }
        public int QuantityToSell { get; set; }
        public string? SoldByUserId { get; set; }
    }
}
