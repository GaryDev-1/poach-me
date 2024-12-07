using AutoMapper;
using WildlifePoaching.API.Models.Domain;
using WildlifePoaching.API.Models.DTOs.Animal;
using WildlifePoaching.API.Models.DTOs.Auth;
using WildlifePoaching.API.Models.DTOs.Transactions;

namespace WildlifePoaching.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, AuthResponse>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name));

            CreateMap<Animal, AnimalDto>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.StolenFrom.Name))
                .ForMember(dest => dest.AnimalType, opt => opt.MapFrom(src => src.Type.Name))
                .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.Images.Select(i => i.FilePath)));

            CreateMap<CreateAnimalDto, Animal>();
            CreateMap<UpdateAnimalDto, Animal>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Transaction, TransactionDto>()
                .ForMember(dest => dest.AnimalName, opt => opt.MapFrom(src => src.Animal.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username));

            CreateMap<CreateTransactionDto, Transaction>();
        }
    }
}
