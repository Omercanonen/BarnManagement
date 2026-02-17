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
        }
    }
}
