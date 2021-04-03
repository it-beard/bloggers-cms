using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Pds.Api.Contracts.Client;
using Pds.Api.Contracts.Content;
using Pds.Api.Contracts.Person;
using Pds.Api.Contracts.Topic;
using Pds.Data.Entities;
using Pds.Services.Models;
using Pds.Services.Models.Content;

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
            
            CreateMap<Bill, ContentListBillDto>();
            CreateMap<Content, ContentDto>()
                .ForMember(
                    dest => dest.ClientName,
                    opt => opt
                        .MapFrom(p => p.Bill.Client.Name));
            CreateMap<Content, GetContentResponse>()
                .ForMember(
                    dest => dest.BillCost,
                    opt => opt
                        .MapFrom(p => p.Bill.Cost))
                .ForMember(
                    dest => dest.BillComment,
                    opt => opt
                        .MapFrom(p => p.Bill.Comment))
                .ForMember(
                    dest => dest.BillStatus,
                    opt => opt
                        .MapFrom(p => p.Bill.Status))
                .ForMember(
                    dest => dest.BillPaymentType,
                    opt => opt
                        .MapFrom(p => p.Bill.PaymentType))
                .ForMember(
                    dest => dest.BillPaidAt,
                    opt => opt
                        .MapFrom(p => p.Bill.PaidAt));
            CreateMap<Client, ClientDto>();
            CreateMap<Brand, BrandForRadioboxGroupDto>();
            CreateMap<Brand, BrandForCheckboxesDto>();
            CreateMap<Client, ClientForLookupDto>()
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
            CreateMap<Topic, GetTopicDto>()
                .ForMember(dest => dest.People, opt => opt.MapFrom(t => t.PersonTopics.Select(pt => pt.Person)));
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
                    dest => dest.Brands,
                    opt => opt
                        .MapFrom(p => BrandsDtoToBrandsCollection(p.Brands.Where( c => c.IsSelected).ToList())));
            CreateMap<CreateTopicRequest, Topic>()
                .ForMember(dest => dest.PersonTopics,
                    opt =>
                        opt.MapFrom(ctr => ctr.People.Where(dto => dto.IsSelected).Select(dto => new PersonTopic(default, dto.Person.Id)).ToList()));
            #endregion
            
            #region Contracts to Models

            CreateMap<ContentBillDto, ContentBillModel>();
            CreateMap<CreateContentRequest, CreateContentModel>()
                .ForMember(
                    dest => dest.BrandId,
                    opt => opt
                        .MapFrom(p => p.BrandId.Value));
            
            #endregion
        }

        private ICollection<Brand> BrandsDtoToBrandsCollection(List<BrandForCheckboxesDto> brands)
        {
            return brands.Select(b => new Brand {Id = b.Id}).ToList();
        }
    }
}