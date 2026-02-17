using BarnManagement.Business.Abstract;
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
                    .Where(a => a.IsActive && a.BarnId == barnId)
                    .ToListAsync();

                if (!animals.Any())
                    return;

                int maturedCount = 0;

                foreach (var animal in animals)
                {
                    animal.AgeMonth += 1;

                    if (!animal.CanProduce && animal.AgeMonth >= 6)
                    {
                        animal.CanProduce = true;
                        maturedCount++;
                    }
                }

                await _context.SaveChangesAsync();

                if (maturedCount > 0)
                    _logger.LogInfo($"AgingService: {maturedCount} animals became producible. BarnId={barnId}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"AgingService failed. BarnId={barnId}", ex);
            }
        }

        //public async Task ProcessAnimalGrowthAsync()
        //{
        //    var growingAnimals = await _context.Animals
        //        .Where(a => a.IsActive && !a.CanProduce)
        //        .ToListAsync();

        //    if (!growingAnimals.Any())
        //        return;

        //    int grownCount = 0;

        //    foreach (var animal in growingAnimals)
        //    {
        //        // Oyun zamanı:
        //        // 1 dakika = 1 ay
        //        double ageInGameMonths =
        //            (DateTime.UtcNow - animal.BirthDate).TotalMinutes;

        //        // Üretim eşiği: 6 ay = 6 dakika
        //        if (ageInGameMonths >= 6)
        //        {
        //            animal.CanProduce = true;
        //            grownCount++;
        //        }
        //    }

        //    if (grownCount > 0)
        //    {
        //        await _context.SaveChangesAsync();

        //        string logMessage =
        //            $"AgingService: {grownCount} animals became producible (>=6 months).";

        //        _logger.LogInfo(logMessage);
        //    }
        //}
    }
}
