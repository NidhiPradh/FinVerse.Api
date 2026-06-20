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
            CreateMap <CustomerDto,CustomerRO>().ReverseMap();


        }

    }
}
