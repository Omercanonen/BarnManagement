using BarnManagement.Business.DTOs;

namespace BarnManagement.Business.Abstract
{
    public interface IInventoryService
    {
        Task<List<InventoryItemDto>> GetInventoryAsync(int barnId);
        Task<SellPreviewDto?> GetSellPreviewAsync(int barnId, int productId);
        Task<bool> SellAsync(SellRequestDto request);
        Task<bool> SellAllAsync(int barnId, int productId, string? soldByUserId);
    }
}
