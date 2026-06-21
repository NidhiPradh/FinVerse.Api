using AutoMapper;
using FinVerse.Core.models;
using FinVerse.Infrastructure.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.Mapper
{
    public class MapperDtoProfile : Profile
    {
        public MapperDtoProfile()
        {
             CreateMap<RegisterRequestEntity, RegisterRequestDto>().ReverseMap();
            CreateMap<LoginRequestEntity, LoginRequestDto>().ReverseMap();
            CreateMap<LoginResponseEntity, LoginResponseDto>().ReverseMap();
            CreateMap<LoginResponseDto, LoginResponseEntity>().ReverseMap();
            CreateMap<CustomerDto, CustomerEntity>().ReverseMap();
            CreateMap<UsersDto, UsersEntity>().ReverseMap();
            CreateMap<CustomerRegDetailsDto, CustomerRegDetailsEntity>().ReverseMap();

        }
    }
}
