using AutoMapper;
using BarnManagement.Business.Abstract;
using BarnManagement.Business.Constants;
using BarnManagement.Business.DTOs;
using BarnManagement.Core.Logging;
using BarnManagement.Data;
using BarnManagement.Model;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace BarnManagement.Business.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly AppDbContext _context;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public InventoryService(AppDbContext context, ILoggerService logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<InventoryItemDto>> GetInventoryAsync(int barnId)
        {
            try
            {
                var items = await _context.BarnInventories
                    .AsNoTracking()
                    .Where(i => i.BarnId == barnId && i.Quantity > 0)
                    .Include(i => i.Product)
                    .OrderBy(i => i.Product.ProductName)
                    .ToListAsync();

                return _mapper.Map<List<InventoryItemDto>>(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(Messages.Error.GeneralError, ex);
                return new List<InventoryItemDto>();
            }
        }

        public async Task<SellPreviewDto?> GetSellPreviewAsync(int barnId, int productId)
        {
            var item = await _context.BarnInventories
                .AsNoTracking()
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.BarnId == barnId && i.ProductId == productId);

            if (item == null) return null;

            return _mapper.Map<SellPreviewDto>(item);
        }

        public async Task<bool> SellAsync(SellRequestDto request)
        {
            if (request.QuantityToSell <= 0)
                return false;

            try
            {
                var inv = await _context.BarnInventories
                    .Include(i => i.Product)
                    .FirstOrDefaultAsync(i => i.BarnId == request.BarnId && i.ProductId == request.ProductId);

                if (inv == null) return false;
                if (inv.Quantity < request.QuantityToSell) return false;

                var barn = await _context.Barns.FirstOrDefaultAsync(b => b.BarnId == request.BarnId);
                if (barn == null) return false;

                decimal unitPrice = inv.Product.ProductPrice;
                decimal total = unitPrice * request.QuantityToSell;

                inv.Quantity -= request.QuantityToSell;
                inv.UpdatedAt = DateTime.UtcNow;

                barn.BarnBalance += total;

                var sale = _mapper.Map<Sale>(request);

                sale.UnitPriceAtSale = unitPrice;
                sale.SaleAmount = total;
                sale.BarnId = request.BarnId;
                sale.ProductId = request.ProductId;


                _context.Sales.Add(sale);

                await _context.SaveChangesAsync();

                _logger.LogInfo(Messages.Info.OperationSuccess);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(Messages.Error.GeneralError, ex);
                return false;
            }
        }

        public async Task<bool> SellAllAsync(int barnId, int productId, string? soldByUserId)
        {
            try
            {
                var preview = await GetSellPreviewAsync(barnId, productId);
                if (preview == null || preview.StockQuantity <= 0)
                    return false;

                return await SellAsync(new SellRequestDto
                {
                    BarnId = barnId,
                    ProductId = productId,
                    QuantityToSell = preview.StockQuantity,
                    SoldByUserId = soldByUserId
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(Messages.Error.GeneralError, ex);
                return false;
            }
        }

        public async Task<string> ExportSalesJsonAsync(int barnId, DateTime? fromUtc = null, DateTime? toUtc = null)
        {
            try
            {
                var query = _context.Sales
                    .AsNoTracking()
                    .Where(s => s.BarnId == barnId)
                    .Include(s => s.Product)
                    .AsQueryable();

                if (fromUtc.HasValue)
                    query = query.Where(s => s.SaleDate >= fromUtc.Value);

                if (toUtc.HasValue)
                    query = query.Where(s => s.SaleDate <= toUtc.Value);

                var sales = await query
                    .OrderByDescending(s => s.SaleDate)
                    .ToListAsync();

                var dto = _mapper.Map<List<SaleExportDto>>(sales);

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                return JsonSerializer.Serialize(dto, options);
            }
            catch (Exception ex)
            {
                _logger.LogError(Messages.Error.GeneralError, ex);
                return "[]";
            }
        }
    }
}
