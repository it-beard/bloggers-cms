using AutoMapper;
using Pds.Api.Contracts.Person;
using Pds.Data.Entities;

namespace Pds.Mappers
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt
                        .MapFrom(p => $"{p.FirstName} {p.ThirdName} {p.LastName}"));
        }
    }
}