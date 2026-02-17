namespace BarnManagement.Business.Abstract
{
    public interface IAgingService
    {
        Task ProcessAnimalGrowthAsync(int barnId);
    }
}
