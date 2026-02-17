using BarnManagement.Business.DTOs;

namespace BarnManagement.Business.Abstract
{
    public interface IProductionService
    {
        Task ProduceAsync(int barnId);
        Task<List<AnimalProductionDto>> GetProductionPotentialAsync(int barnId);
        List<AccumulatedProductDto> GetAccumulatedProducts(int barnId);
        Task CollectManualProductsAsync(int barnId, List<AccumulatedProductDto> collectedItems);
    }
}
