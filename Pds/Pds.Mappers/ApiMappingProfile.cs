using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Pds.Api.Contracts.Client;
using Pds.Api.Contracts.Content;
using Pds.Api.Contracts.Person;
using Pds.Data.Entities;
using Pds.Services.Models;

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
            CreateMap<Content, ContentDto>()
                .ForMember(
                    dest => dest.BillCost,
                    opt => opt
                        .MapFrom(p => p.Bill.Cost))
                .ForMember(
                    dest => dest.BillStatus,
                    opt => opt
                        .MapFrom(p => p.Bill.Status))
                .ForMember(
                    dest => dest.ClientName,
                    opt => opt
                        .MapFrom(p => p.Bill.Client.Name));
            CreateMap<Client, ClientDto>();
            CreateMap<Channel, ChannelForRadioboxGroupDto>();
            CreateMap<Channel, ChannelForCheckboxesDto>();
            CreateMap<Client, ClientForLookupDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt
                        .MapFrom((p, s) =>
                            s.Id = p.Id == Guid.Empty ? null : p.Id))
                .ForMember(
                    dest => dest.Name,
                    opt => opt
                        .MapFrom((p, s) =>
                            s.Name = p.Name ?? "Не выбрано"));
            CreateMap<Person, PersonForLookupDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt
                        .MapFrom((p, s) => 
                            s.Id = p.Id == Guid.Empty ? 
                                null : 
                                p.Id)) // Transform first person with id =  Guid.Empty element to id = null
                .ForMember(
                    dest => dest.FullName,
                    opt => opt
                        .MapFrom((p,s) => 
                            s.FullName = string.IsNullOrEmpty(p.FirstName) ? 
                                "Не выбрано" : 
                                $"{p.FirstName} {p.ThirdName} {p.LastName}"));
            
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
            
            #region Contracts to Models

            CreateMap<CreateContentRequest, CreateContentModel>()
                .ForMember(
                    dest => dest.ChannelId,
                    opt => opt
                        .MapFrom(p => p.ChannelId.Value))
                .ForMember(
                    dest => dest.ClientId,
                    opt => opt
                        .MapFrom(p => p.ClientId.Value));
            
            #endregion
        }

        private ICollection<Channel> ChannelsDtoToChannelsCollection(List<ChannelForCheckboxesDto> channels)
        {
            return channels.Select(channel => new Channel {Id = channel.Id}).ToList();
        }
    }
}