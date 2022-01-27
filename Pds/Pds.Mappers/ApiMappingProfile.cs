using AutoMapper;
using Pds.Api.Contracts;
using Pds.Api.Contracts.Bill;
using Pds.Api.Contracts.Brand;
using Pds.Api.Contracts.Client;
using Pds.Api.Contracts.Content;
using Pds.Api.Contracts.Content.CreateContent;
using Pds.Api.Contracts.Content.EditContent;
using Pds.Api.Contracts.Content.GetContent;
using Pds.Api.Contracts.Content.GetContents;
using Pds.Api.Contracts.Cost;
using Pds.Api.Contracts.Gift;
using Pds.Api.Contracts.Person;
using Pds.Api.Contracts.Settings;
using Pds.Data.Entities;
using Pds.Services.Models.Bill;
using Pds.Services.Models.Client;
using Pds.Services.Models.Content;
using Pds.Services.Models.Cost;
using Pds.Services.Models.Gift;
using Pds.Services.Models.Person;
using Pds.Services.Models.Setting;

namespace Pds.Mappers;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        #region Entities to Contracts

        CreateMap<Person, GetContentPersonDto>();
        CreateMap<Person, GetContentsPersonDto>();
        CreateMap<Person, PersonDto>()
            .ForMember(
                dest => dest.FullName,
                opt => opt
                    .MapFrom(p => $"{p.LastName} {p.FirstName} {p.ThirdName}"))
            .ForMember(
                dest => dest.Location,
                opt => opt
                    .MapFrom(p => string.IsNullOrEmpty(p.City) ? 
                        $"{p.Country}" : 
                        $"{p.Country}, {p.City}"));
        CreateMap<Person, PersonForLookupDto>()
            .ForMember(
                dest => dest.FullName,
                opt => opt
                    .MapFrom((p,s) => 
                        s.FullName = string.IsNullOrEmpty(p.FirstName) ? 
                            "Не выбрано" : 
                            $"{p.LastName} {p.FirstName} {p.ThirdName}"));

        CreateMap<Resource, ResourceDto>();
        CreateMap<Resource, GetContentPersonResourceDto>();
            
        CreateMap<Content, BillContentDto>();
        CreateMap<Content, CostContentDto>();
        CreateMap<Content, PersonContentDto>();
        CreateMap<Content, GiftContentDto>();
        CreateMap<Content, Pds.Api.Contracts.Cost.ContentForLookupDto>()
            .ForMember(
                dest => dest.Title,
                opt => opt
                    .MapFrom((p, s) =>
                        s.Title = string.IsNullOrEmpty(p.Title) ? 
                            "Не выбрано" : 
                            $"{p.ReleaseDate:dd.MM} / {p.Title}"));
        CreateMap<Content, Pds.Api.Contracts.Gift.ContentForLookupDto>()
            .ForMember(
                dest => dest.Title,
                opt => opt
                    .MapFrom((p, s) =>
                        s.Title = string.IsNullOrEmpty(p.Title) ? 
                            "Не выбрано" : 
                            $"{p.ReleaseDate:dd.MM} / {p.Title}"));
        CreateMap<Content, GetContentsContentDto>()
            .ForMember(
                dest => dest.ClientName,
                opt => opt
                    .MapFrom(p => p.Bill.Client.Name));
        CreateMap<Content, GetContentResponse>();
        CreateMap<Content, GetContentForPayResponse>();

        CreateMap<Brand, BrandDto>();
        CreateMap<Brand, BrandFullDto>();
        CreateMap<Brand, BrandForCheckboxesDto>();

        CreateMap<Client, ClientDto>();
        CreateMap<Client, GetClientResponse>();
        CreateMap<Client, GetContentBillClientDto>();
        CreateMap<Client, Pds.Api.Contracts.Content.ClientForLookupDto>()
            .ForMember(
                dest => dest.Name,
                opt => opt
                    .MapFrom((p, s) =>
                        s.Name = p.Name ?? "Не выбрано"));
        CreateMap<Client, Pds.Api.Contracts.Bill.ClientForLookupDto>()
            .ForMember(
                dest => dest.Name,
                opt => opt
                    .MapFrom((p, s) =>
                        s.Name = p.Name ?? "Не выбрано"));

        CreateMap<Bill, BillDto>();
        CreateMap<Bill, ClientBillDto>();
        CreateMap<Bill, GetBillResponse>();
        CreateMap<Bill, GetContentBillDto>();
        CreateMap<Bill, GetContentsBillDto>();
        CreateMap<Bill, GetContentBillForPayResponse>();

        CreateMap<Cost, CostDto>();
        CreateMap<Cost, GetCostResponse>();
        CreateMap<Cost, GetContentCostDto>();

        CreateMap<Brand, BrandDto>();
        
        CreateMap<Gift, GetGiftResponse>();
        CreateMap<Gift, GiftDto>() 
            .ForMember(
                dest => dest.SortDate,
                opt => opt
                    .MapFrom(p => GetSortDateForGiftDto(p)));
        
        CreateMap<Setting, SettingDto>();
        CreateMap<Setting, GetSettingResponse>();

        #endregion

        #region Contracts to Entities

        CreateMap<CreateClientRequest, Client>();
        CreateMap<CreateCostRequest, Cost>();
        CreateMap<CreateBillRequest, Bill>();
        CreateMap<CreateGiftRequest, Gift>();
        CreateMap<CreateBrandRequest, Brand>();
        CreateMap<ResourceDto, Resource>()
            .ForMember(
                dest => dest.CreatedAt,
                opt => opt
                    .MapFrom(p => DateTime.UtcNow));
        CreateMap<CreatePersonRequest, Person>()
            .ForMember(
                dest => dest.Brands,
                opt => opt
                    .MapFrom(p => 
                        BrandsForCheckboxesDtoToBrandsCollection(
                            p.Brands.Where( 
                                c => c.IsSelected).ToList())));

        #endregion
            
        #region Contracts to Models

        CreateMap<EditContentBillDto, EditContentBillModel>();
        CreateMap<EditContentRequest, EditContentModel>();
        CreateMap<EditClientRequest, EditClientModel>();
        CreateMap<EditCostRequest, EditCostModel>();
        CreateMap<EditGiftRequest, EditGiftModel>();
        CreateMap<EditSettingRequest, EditSettingModel>();
        CreateMap<EditBillRequest, EditBillModel>();
        CreateMap<CreateContentBillDto, CreateContentBillModel>();
        CreateMap<CreateContentRequest, CreateContentModel>()
            .ForMember(
                dest => dest.BrandId,
                opt => opt
                    .MapFrom(p => p.BrandId.Value));
        
        CreateMap<EditPersonRequest, EditPersonModel>();
        CreateMap<BrandForCheckboxesDto, BrandForCheckboxesModel>();
        CreateMap<ResourceDto, EditResourcePersonModel>();

        #endregion

        #region Contract to Contract

        CreateMap<GetContentResponse, EditContentRequest>();
        CreateMap<GetContentBillDto, EditContentBillDto>();
        CreateMap<GetCostResponse, EditCostRequest>();
        CreateMap<GetBillResponse, EditBillRequest>();
        CreateMap<GetClientResponse, EditClientRequest>();
        CreateMap<GetSettingResponse, EditSettingRequest>();
        CreateMap<GetGiftResponse, EditGiftRequest>();
        CreateMap<GetPersonResponse, EditPersonRequest>()
            .ForMember(
                dest => dest.Brands,
                opt => opt.MapFrom(p => BrandsDtoToBrandsForCheckboxesDto(p.Brands)));
        CreateMap<PersonDto, GetPersonResponse>();
        CreateMap<BrandDto, Pds.Web.Models.Content.BrandFilterItem>();
        CreateMap<BrandDto, Pds.Web.Models.Bill.BrandFilterItem>();
        CreateMap<BrandDto, Pds.Web.Models.Cost.BrandFilterItem>();
        CreateMap<BrandDto, Pds.Web.Models.Person.BrandFilterItem>();
        CreateMap<BrandDto, Pds.Web.Models.Gift.BrandFilterItem>();

        #endregion

        #region Models to Entities

        CreateMap<EditContentBillModel, Bill>();

        #endregion
    }

    private ICollection<Brand> BrandsForCheckboxesDtoToBrandsCollection(List<BrandForCheckboxesDto> brands)
    {
        return brands.Select(b => new Brand {Id = b.Id}).ToList();
    }
        
    private List<BrandForCheckboxesDto> BrandsDtoToBrandsForCheckboxesDto(List<BrandDto> brands)
    {
        return brands
            .Select(b => 
                new BrandForCheckboxesDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    IsSelected = true
                })
            .ToList();
    }

    private DateTime GetSortDateForGiftDto(Gift gift)
    {
        var sortDate = gift.CreatedAt;
        if (gift.Content != null)
        {
            sortDate = gift.Content.ReleaseDate;
        }
        return sortDate;
    }
}