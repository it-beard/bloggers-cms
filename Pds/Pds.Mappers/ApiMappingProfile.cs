using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Pds.Api.Contracts.Client;
using Pds.Api.Contracts.Content;
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
                        .MapFrom(p => $"{p.FirstName} {p.ThirdName} {p.LastName}"))
                .ForMember(
                    dest => dest.Location,
                    opt => opt
                        .MapFrom(p => $"{p.Country} {p.City}"));
            CreateMap<Resource, ResourceDto>();
            CreateMap<Content, ContentDto>();
            CreateMap<Client, ClientDto>();
            CreateMap<Channel, Pds.Api.Contracts.Content.ChannelDto>();
            CreateMap<Channel, Pds.Api.Contracts.Person.ChannelDto>();
            
            #endregion

            #region Contracts to Entities

            CreateMap<CreateClientRequest, Client>();
            CreateMap<ResourceDto, Resource>()
                .ForMember(
                    dest => dest.CreatedAt,
                    opt => opt
                        .MapFrom(p => DateTime.UtcNow));
            CreateMap<CreatePersonRequest, Person>()
                .ForMember(
                    dest => dest.Channels,
                    opt => opt
                        .MapFrom(p => ChannelsDtoToChannelsCollection(p.Channels.Where( c => c.IsSelected).ToList())));
            
            #endregion
        }

        private ICollection<Channel> ChannelsDtoToChannelsCollection(List<Pds.Api.Contracts.Person.ChannelDto> channels)
        {
            return channels.Select(channel => new Channel {Id = channel.Id}).ToList();
        }
    }
}