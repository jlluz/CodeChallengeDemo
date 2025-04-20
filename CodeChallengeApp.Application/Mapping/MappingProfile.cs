using AutoMapper;
using CodeChallengeApp.Application.DTOs;
using CodeChallengeApp.Domain.Entities;

namespace CodeChallengeApp.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}