using AutoMapper;
using FinVerse.Api.ROmodels;
using FinVerse.Core.models;
using FinVerse.Infrastructure.models;

namespace FinVerse.Api.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<RegisterRequest, RegisterRequestDto>().ReverseMap();
            CreateMap<LoginRequestRo, LoginRequestDto>().ReverseMap();
            CreateMap<LoginResponseDto, LoginResponseEntity>().ReverseMap();
            CreateMap <LoginResponseEntity, LoginResponseRo>().ReverseMap();
            CreateMap <CustomerDto,CustomerRo>().ReverseMap();
            CreateMap<CustomerRegDetailsDto, CustomerRegDetailsRo>().ReverseMap();
            CreateMap<UsersRo, UsersDto>().ReverseMap();
            CreateMap<KYCDetailsRo, KYCDetailsDto>().ReverseMap();
            CreateMap<CustomerDetailsRo, CustomerDetailsDto>().ReverseMap();
            CreateMap<StatesRo, StatesDto>().ReverseMap();
            CreateMap<DistrictRo, DistrictDto>().ReverseMap();
            CreateMap<CurrencyNameRo, CurrencyNameDto>().ReverseMap();

        }

    }
}
