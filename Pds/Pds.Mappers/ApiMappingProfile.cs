using AutoMapper;
using Pds.Data.Entities;
using Pds.Api.Contracts;

namespace Pds.Mappings
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Person, PersonContract>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt
                        .MapFrom(p => $"{p.FirstName} {p.ThirdName} {p.LastName}"));
        }
    }
}