using BarnManagement.Business.Abstract;
using BarnManagement.Business.Constants;
using BarnManagement.Core.Logging;
using BarnManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace BarnManagement.Business.Services
{
    public class AgingService : IAgingService
    {
        private readonly AppDbContext _context;
        private readonly ILoggerService _logger;

        public AgingService(AppDbContext context, ILoggerService logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task ProcessAnimalGrowthAsync(int barnId)
        {
            try
            {
                var animals = await _context.Animals
                    .Include(a => a.AnimalSpecies)
                    .Where(a => a.IsActive && a.BarnId == barnId)
                    .ToListAsync();

                if (!animals.Any())
                    return;

                int maturedCount = 0;
                int deadCount = 0;

                foreach (var animal in animals)
                {
                    animal.AgeMonth += 1;

                    int lifeSpan = animal.AnimalSpecies.AnimalSpeciesLifeSpan;

                    if (lifeSpan > 0 && animal.AgeMonth >= lifeSpan)
                    {
                        animal.CanProduce = false;
                        animal.IsActive = false;
                        deadCount++;
                        continue;
                    }

                    if (!animal.CanProduce && animal.AgeMonth >= 6)
                    {
                        animal.CanProduce = true;
                        maturedCount++;
                    }
                }

                await _context.SaveChangesAsync();

                if (maturedCount > 0)
                    _logger.LogInfo(string.Format(Messages.Info.AnimalsGrewUp, maturedCount));

                if (deadCount > 0)
                    _logger.LogInfo(string.Format(Messages.Info.AnimalsDied,deadCount));
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format(Messages.Error.AgingServiceError, ex.Message), ex);
            }
        }
    }
}
