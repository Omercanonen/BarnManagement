using BarnManagement.Business.Abstract;
using BarnManagement.Business.DTOs;
using BarnManagement.Core.Logging;
using BarnManagement.Data;
using BarnManagement.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace BarnManagement.Business.Services
{
    public class ProductionService : IProductionService
    {

        private readonly AppDbContext _context;
        private readonly ILoggerService _logger;

        private static readonly ConcurrentDictionary<int, Dictionary<int, AccumulatedProductDto>> _pending
            = new();

        private static readonly ConcurrentDictionary<int, object> _locks
            = new();

        public ProductionService(AppDbContext context, ILoggerService logger)
        {
            _context = context;
            _logger = logger;
        }

        private static object GetLock(int barnId)
            => _locks.GetOrAdd(barnId, _ => new object());

        public async Task<List<AnimalProductionDto>> GetProductionPotentialAsync(int barnId)
        {
            try
            {
                var productionGroups = await _context.Animals
                    .Where(a => a.IsActive && a.CanProduce && a.BarnId == barnId)
                    .GroupBy(a => a.AnimalSpeciesId)
                    .Select(g => new
                    {
                        SpeciesId = g.Key,
                        Count = g.Count()
                    })
                    .ToListAsync();

                if (!productionGroups.Any())
                    return new List<AnimalProductionDto>();

                var speciesIds = productionGroups
                    .Select(x => x.SpeciesId)
                    .Distinct()
                    .ToList();

                var species = await _context.AnimalSpecies
                    .Where(s => s.IsActive && speciesIds.Contains(s.AnimalSpeciesId))
                    .Select(s => new
                    {
                        s.AnimalSpeciesId,
                        s.AnimalSpeciesName
                    })
                    .ToListAsync();

                var products = await _context.Products
                    .Where(p => p.IsActive && speciesIds.Contains(p.AnimalSpeciesId))
                    .Select(p => new
                    {
                        p.ProductId,
                        p.ProductName,
                        p.AnimalSpeciesId
                    })
                    .ToListAsync();

                var result = new List<AnimalProductionDto>();

                foreach (var group in productionGroups)
                {
                    var sp = species.FirstOrDefault(s => s.AnimalSpeciesId == group.SpeciesId);
                    var pr = products.FirstOrDefault(p => p.AnimalSpeciesId == group.SpeciesId);

                    result.Add(new AnimalProductionDto
                    {
                        SpeciesName = sp?.AnimalSpeciesName ?? "Unknown",
                        Count = group.Count,
                        ProductName = pr?.ProductName ?? "-",
                        ProductId = pr?.ProductId ?? 0
                    });
                }

                return result
                    .OrderBy(x => x.SpeciesName)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetProductionPotentialAsync failed. BarnId={barnId}", ex);
                return new List<AnimalProductionDto>();
            }
        }


        public async Task ProduceAsync(int barnId)
        {
            try
            {
                var productionGroups = await _context.Animals
                    .Where(a => a.IsActive && a.CanProduce && a.BarnId == barnId)
                    .GroupBy(a => a.AnimalSpeciesId)
                    .Select(g => new
                    {
                        SpeciesId = g.Key,
                        AnimalCount = g.Count()
                    })
                    .ToListAsync();

                if (!productionGroups.Any())
                {
                    _logger.LogInfo($"No producible animals found. BarnId={barnId}");
                    return;
                }

                var speciesIds = productionGroups.Select(x => x.SpeciesId).Distinct().ToList();

                var products = await _context.Products
                    .Where(p => p.IsActive && speciesIds.Contains(p.AnimalSpeciesId))
                    .Select(p => new { p.ProductId, p.ProductName, p.AnimalSpeciesId })
                    .ToListAsync();

                if (!products.Any())
                {
                    _logger.LogWarning($"No active products found for producible species. BarnId={barnId}");
                    return;
                }

                lock (GetLock(barnId))
                {
                    var cart = _pending.GetOrAdd(barnId, _ => new Dictionary<int, AccumulatedProductDto>());

                    foreach (var group in productionGroups)
                    {
                        var product = products.FirstOrDefault(p => p.AnimalSpeciesId == group.SpeciesId);
                        if (product == null) continue;

                        int producedQty = group.AnimalCount; // 1 dk'da hayvan sayısı kadar üret
                        if (producedQty <= 0) continue;

                        if (!cart.TryGetValue(product.ProductId, out var item))
                        {
                            item = new AccumulatedProductDto
                            {
                                ProductId = product.ProductId,
                                ProductName = product.ProductName,
                                TotalQuantity = 0
                            };
                            cart[product.ProductId] = item;
                        }

                        item.TotalQuantity += producedQty;
                    }
                }

                _logger.LogInfo($"Production cycle accumulated. BarnId={barnId}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProduceAsync failed. BarnId={barnId}", ex);
            }
        }

        public List<AccumulatedProductDto> GetAccumulatedProducts(int barnId)
        {
            try
            {
                lock (GetLock(barnId))
                {
                    if (!_pending.TryGetValue(barnId, out var cart))
                        return new List<AccumulatedProductDto>();

                    return cart.Values
                        .Where(x => x.TotalQuantity > 0)
                        .Select(x => new AccumulatedProductDto
                        {
                            ProductId = x.ProductId,
                            ProductName = x.ProductName,
                            TotalQuantity = x.TotalQuantity
                        })
                        .OrderBy(x => x.ProductName)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAccumulatedProducts failed. BarnId={barnId}", ex);
                return new List<AccumulatedProductDto>();
            }
        }

        public async Task CollectManualProductsAsync(int barnId, List<AccumulatedProductDto> collectedItems)
        {
            try
            {
                if (collectedItems == null || collectedItems.Count == 0)
                {
                    _logger.LogWarning($"Collect called with empty list. BarnId={barnId}");
                    return;
                }

                foreach (var item in collectedItems.Where(x => x.TotalQuantity > 0))
                {
                    var inventoryItem = await _context.BarnInventories
                        .FirstOrDefaultAsync(i => i.BarnId == barnId && i.ProductId == item.ProductId);

                    if (inventoryItem == null)
                    {
                        inventoryItem = new BarnInventory
                        {
                            BarnId = barnId,
                            ProductId = item.ProductId,
                            Quantity = 0,
                            UpdatedAt = DateTime.UtcNow
                        };
                        _context.BarnInventories.Add(inventoryItem);
                    }

                    inventoryItem.Quantity += item.TotalQuantity;
                    inventoryItem.UpdatedAt = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync();

                lock (GetLock(barnId))
                {
                    if (_pending.TryGetValue(barnId, out var cart))
                    {
                        foreach (var item in collectedItems)
                            cart.Remove(item.ProductId);
                    }
                }

                _logger.LogInfo($"Collect completed. BarnId={barnId}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"CollectManualProductsAsync failed. BarnId={barnId}", ex);
            }
        }

    }
}
