using AutoMapper;
using Pds.Api.Contracts.Person;
using Pds.Data.Entities;

namespace Pds.Mappers
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            #region Entities to Contracts
            
            CreateMap<Person, PersonDto>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt
                        .MapFrom(p => $"{p.FirstName} {p.ThirdName} {p.LastName}"));
            
            #endregion

            #region Contracts to Entities
            
            CreateMap<CreatePersonRequest, Person>();
            
            #endregion
        }
    }
}