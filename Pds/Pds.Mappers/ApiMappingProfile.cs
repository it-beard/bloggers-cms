using System;
using AutoMapper;
using Pds.Api.Contracts.Person;
using Pds.Data.Entities;
using Pds.Data.Repositories;

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
                        .MapFrom(p => $"{p.FirstName} {p.ThirdName} {p.LastName}"))
                .ForMember(
                    dest => dest.Location,
                    opt => opt
                        .MapFrom(p => $"{p.Country} {p.City}"));
            CreateMap<Resource, ResourceDto>();
            
            #endregion

            #region Contracts to Entities
            
            CreateMap<GetPersonsRequest, SearchSettings>();

            CreateMap<Api.Contracts.Paging.OrderSetting, OrderSetting>();
            CreateMap<Api.Contracts.Paging.PageSettings, PageSettings>();
            CreateMap<Api.Contracts.Paging.FilterSettings, FilterSettings>();

            CreateMap<CreatePersonRequest, Person>();
            CreateMap<ResourceDto, Resource>()
                .ForMember(
                    dest => dest.CreatedAt,opt => opt
                        .MapFrom(p => DateTime.UtcNow));
            
            #endregion
        }
    }
}