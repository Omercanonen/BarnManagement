using AutoMapper;
using BarnManagement.Business.DTOs;
using BarnManagement.Model;

namespace BarnManagement.Business.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserCreateDto, ApplicationUser>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => $"{src.UserName}@barn.com"))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => true));

            CreateMap<ApplicationUser, UserListDto>()
                .ReverseMap();

            CreateMap<PurchaseAnimalDto, Animal>()
                .ForMember(dest => dest.AgeMonth, opt => opt.MapFrom(_ => 3))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.CanProduce, opt => opt.MapFrom(_ => false))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(_ => true));

            CreateMap<BarnCreateDto, Barn>()
                .ForMember(dest => dest.BarnBalance, opt => opt.MapFrom(src => 1000m)) 
                .ForMember(dest => dest.BarnCapacity, opt => opt.MapFrom(src => 0))    
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<BarnInventory, InventoryItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Product.ProductPrice))
                .ForMember(dest => dest.StockQuantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<BarnInventory, SellPreviewDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.StockQuantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Product.ProductPrice));

            CreateMap<SellRequestDto, Sale>()
                .ForMember(dest => dest.SaleQuantity, opt => opt.MapFrom(src => src.QuantityToSell))
                .ForMember(dest => dest.SoldByUserId, opt => opt.MapFrom(src => src.SoldByUserId))
                .ForMember(dest => dest.SaleDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(_ => true))
                .ForMember(dest => dest.UnitPriceAtSale, opt => opt.Ignore())
                .ForMember(dest => dest.SaleAmount, opt => opt.Ignore());

            CreateMap<AccumulatedProductDto, AccumulatedProductDto>();

            CreateMap<AccumulatedProductDto, BarnInventory>()
                .ForMember(dest => dest.BarnInventoryId, opt => opt.Ignore())
                .ForMember(dest => dest.BarnId, opt => opt.Ignore())  
                .ForMember(dest => dest.Barn, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.TotalQuantity))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<Sale, SaleExportDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));


        }
    }
}
