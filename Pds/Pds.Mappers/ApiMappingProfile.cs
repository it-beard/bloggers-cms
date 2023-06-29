using AutoMapper;
using Pds.Api.Contracts;
using Pds.Api.Contracts.Controllers;
using Pds.Api.Contracts.Controllers.Bill.CreateBill;
using Pds.Api.Contracts.Controllers.Bill.EditBill;
using Pds.Api.Contracts.Controllers.Bill.GetBill;
using Pds.Api.Contracts.Controllers.Bill.GetBills;
using Pds.Api.Contracts.Controllers.Brand.CreateBrand;
using Pds.Api.Contracts.Controllers.Brand.EditBrand;
using Pds.Api.Contracts.Controllers.Brand.GetBrand;
using Pds.Api.Contracts.Controllers.Brand.GetBrands;
using Pds.Api.Contracts.Controllers.Client.CreateClient;
using Pds.Api.Contracts.Controllers.Client.EditClient;
using Pds.Api.Contracts.Controllers.Client.GetClient;
using Pds.Api.Contracts.Controllers.Client.GetClients;
using Pds.Api.Contracts.Controllers.Content;
using Pds.Api.Contracts.Controllers.Content.CreateContent;
using Pds.Api.Contracts.Controllers.Content.EditContent;
using Pds.Api.Contracts.Controllers.Content.GetContent;
using Pds.Api.Contracts.Controllers.Content.GetContents;
using Pds.Api.Contracts.Controllers.Cost;
using Pds.Api.Contracts.Controllers.Cost.CreateCost;
using Pds.Api.Contracts.Controllers.Cost.EditCost;
using Pds.Api.Contracts.Controllers.Cost.GetCost;
using Pds.Api.Contracts.Controllers.Cost.GetCosts;
using Pds.Api.Contracts.Controllers.Dashboard.GetContentStatistics;
using Pds.Api.Contracts.Controllers.Dashboard.GetCountriesStatistics;
using Pds.Api.Contracts.Controllers.Dashboard.GetMoneyStatistics;
using Pds.Api.Contracts.Controllers.Gift.CreateGift;
using Pds.Api.Contracts.Controllers.Gift.EditGift;
using Pds.Api.Contracts.Controllers.Gift.GetGift;
using Pds.Api.Contracts.Controllers.Gift.GetGifts;
using Pds.Api.Contracts.Controllers.Person;
using Pds.Api.Contracts.Controllers.Person.CreatePerson;
using Pds.Api.Contracts.Controllers.Person.EditPerson;
using Pds.Api.Contracts.Controllers.Person.GetPerson;
using Pds.Api.Contracts.Controllers.Person.GetPersons;
using Pds.Api.Contracts.Controllers.Settings.EditSetting;
using Pds.Api.Contracts.Controllers.Settings.GetSetting;
using Pds.Api.Contracts.Controllers.Settings.GetSettings;
using Pds.Core.Enums;
using Pds.Data.Entities;
using Pds.Services.Models.Bill;
using Pds.Services.Models.Brand;
using Pds.Services.Models.Client;
using Pds.Services.Models.Content;
using Pds.Services.Models.Cost;
using Pds.Services.Models.Dashboard;
using Pds.Services.Models.Gift;
using Pds.Services.Models.Person;
using Pds.Services.Models.Setting;
using ClientForLookupDto = Pds.Api.Contracts.Controllers.Bill.ClientForLookupDto;

namespace Pds.Mappers;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        #region Entities to Contracts

        CreateMap<Person, GetContentPersonDto>();
        CreateMap<Client, GetContentsClientDto>();
        CreateMap<Person, GetContentsPersonDto>();
        CreateMap<Person, GetPersonResponse>()
            .ForMember(
                dest => dest.FullName,
                opt => opt
                    .MapFrom(p => $"{p.LastName} {p.FirstName} {p.ThirdName}".Trim()))
            .ForMember(
                dest => dest.Location,
                opt => opt
                    .MapFrom(p => string.IsNullOrEmpty(p.City) ?
                        $"{p.Country}" :
                        $"{p.Country}, {p.City}"))
            .ForMember(
                dest => dest.ContentsCount,
                opt => opt
                    .MapFrom(p => p.Contents == null ? 0 : p.Contents.Count));
        CreateMap<Person, GetPersonsPersonDto>()
            .ForMember(
                dest => dest.FullName,
                opt => opt
                    .MapFrom(p => $"{p.LastName} {p.FirstName} {p.ThirdName}".Trim()))
            .ForMember(
                dest => dest.Location,
                opt => opt
                    .MapFrom(p => string.IsNullOrEmpty(p.City) ?
                        $"{p.Country}" :
                        $"{p.Country}, {p.City}"))
            .ForMember(
                dest => dest.ContentsCount,
                opt => opt
                    .MapFrom(p => p.Contents == null ? 0 : p.Contents.Count));
        CreateMap<Person, PersonForLookupDto>()
            .ForMember(
                dest => dest.FullName,
                opt => opt
                    .MapFrom((p,s) =>
                        s.FullName = string.IsNullOrEmpty(p.FirstName) ?
                            "Не выбрано" :
                            $"{p.LastName} {p.FirstName} {p.ThirdName}".Trim()));

        CreateMap<Resource, ResourceDto>();
        CreateMap<Resource, GetContentPersonResourceDto>();

        CreateMap<Content, GetBillContentDto>();
        CreateMap<Content, EditBillContentDto>();
        CreateMap<Content, GetBillsContentDto>();
        CreateMap<Content, GetCostContentDto>();
        CreateMap<Content, PersonContentDto>();
        CreateMap<Content, GetGiftContentDto>();
        CreateMap<Content, GetGiftsContentDto>();
        CreateMap<Content, EditGiftContentDto>();
        CreateMap<Content, ContentForLookupDto>()
            .ForMember(
                dest => dest.Title,
                opt => opt
                    .MapFrom((p, s) =>
                        s.Title = string.IsNullOrEmpty(p.Title) ?
                            "Не выбрано" :
                            $"{p.ReleaseDate:dd.MM} / {p.Title}"));
        CreateMap<Content, Api.Contracts.Controllers.Gift.ContentForLookupDto>()
            .ForMember(
                dest => dest.Title,
                opt => opt
                    .MapFrom((p, s) =>
                        s.Title = string.IsNullOrEmpty(p.Title) ?
                            "Не выбрано" :
                            $"{p.ReleaseDate:dd.MM} / {p.Title}"));
        CreateMap<Content, GetContentsContentDto>()
            .ForMember(
                dest => dest.Client,
                opt => opt
                    .MapFrom(p => p.Bill.Client))
            .ForMember(
                dest => dest.BillPaymentStatus,
                opt => opt
                    .MapFrom(p => p.Bill == null ? (PaymentStatus?) null : p.Bill.PaymentStatus));
        CreateMap<Content, GetContentResponse>()
            .ForMember(
                dest => dest.BillPaymentStatus,
                opt => opt
                    .MapFrom(p => p.Bill == null ? (PaymentStatus?) null : p.Bill.PaymentStatus))
            .ForMember(
                dest => dest.BrandName,
                opt => opt
                    .MapFrom(p => p.Brand == null ? string.Empty : p.Brand.Name));

        CreateMap<Content, GetContentForPayResponse>();

        CreateMap<Brand, BrandDto>();
        CreateMap<Brand, BrandForCheckboxesDto>();
        CreateMap<Brand, GetBrandResponse>();

        CreateMap<Client, GetClientResponse>();
        CreateMap<Client, GetBillsClientDto>();
        CreateMap<Client, GetContentBillClientDto>();
        CreateMap<Client, GetClientsClientDto>()
            .ForMember(
                dest => dest.BillsCount,
                opt => opt
                    .MapFrom(p => p.Bills == null ? 0 : p.Bills.Count));
        CreateMap<Client, GetClientResponse>()
            .ForMember(
                dest => dest.BillsCount,
                opt => opt
                    .MapFrom(p => p.Bills == null ? 0 : p.Bills.Count));
        CreateMap<Client, Api.Contracts.Controllers.Content.ClientForLookupDto>()
            .ForMember(
                dest => dest.Name,
                opt => opt
                    .MapFrom((p, s) =>
                        s.Name = p.Name ?? "Не выбрано"));
        CreateMap<Client, ClientForLookupDto>()
            .ForMember(
                dest => dest.Name,
                opt => opt
                    .MapFrom((p, s) =>
                        s.Name = p.Name ?? "Не выбрано"));

        CreateMap<Bill, GetBillsBillDto>();
        CreateMap<Bill, GetClientBillDto>();
        CreateMap<Bill, GetClientsBillDto>();
        CreateMap<Bill, GetBillResponse>();
        CreateMap<Bill, GetContentBillDto>();
        CreateMap<Bill, GetContentsBillDto>();
        CreateMap<Bill, GetContentBillForPayResponse>();

        CreateMap<Cost, GetCostsCostDto>();
        CreateMap<Cost, GetCostResponse>();
        CreateMap<Cost, GetContentCostDto>();

        CreateMap<Brand, BrandDto>();

        CreateMap<Gift, GetGiftResponse>()
            .ForMember(
                dest => dest.SortDate,
                opt => opt
                    .MapFrom(p => GetSortDateForGiftDto(p)));
        CreateMap<Gift, GetGiftsGiftDto>()
            .ForMember(
                dest => dest.SortDate,
                opt => opt
                    .MapFrom(p => GetSortDateForGiftDto(p)));

        CreateMap<Setting, GetSettingsSettingDto>();
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
        CreateMap<EditBrandRequest, EditBrandModel>();
        CreateMap<EditCostRequest, EditCostModel>();
        CreateMap<EditGiftRequest, EditGiftModel>();
        CreateMap<EditSettingRequest, EditSettingModel>();
        CreateMap<EditBillRequest, EditBillModel>();
        CreateMap<CreateContentBillDto, CreateContentBillModel>();
        CreateMap<CreateContentRequest, CreateContentModel>();

        CreateMap<EditPersonRequest, EditPersonModel>();
        CreateMap<BrandForCheckboxesDto, BrandForCheckboxesModel>();
        CreateMap<ResourceDto, EditResourcePersonModel>();

        #endregion

        #region Contract to Contract

        CreateMap<GetContentResponse, EditContentRequest>();
        CreateMap<GetCostResponse, EditCostRequest>();

        CreateMap<GetBillResponse, EditBillRequest>();
        CreateMap<GetBillContentDto, EditBillContentDto>();

        CreateMap<GetClientResponse, EditClientRequest>();
        CreateMap<GetSettingResponse, EditSettingRequest>();
        CreateMap<GetGiftResponse, EditGiftRequest>();
        CreateMap<GetPersonResponse, EditPersonRequest>()
            .ForMember(
                dest => dest.Brands,
                opt => opt.MapFrom(p => BrandsDtoToBrandsForCheckboxesDto(p.Brands)));
        CreateMap<GetBrandResponse, EditBrandRequest>();
        CreateMap<GetContentBillDto, EditContentBillDto>();
        CreateMap<GetGiftContentDto, EditGiftContentDto>();
        CreateMap<BrandDto, Pds.Web.Models.Content.BrandFilterItem>();
        CreateMap<BrandDto, Pds.Web.Models.Bill.BrandFilterItem>();
        CreateMap<BrandDto, Pds.Web.Models.Cost.BrandFilterItem>();
        CreateMap<BrandDto, Pds.Web.Models.Person.BrandFilterItem>();
        CreateMap<BrandDto, Pds.Web.Models.Gift.BrandFilterItem>();

        #endregion

        #region Models to Entities

        CreateMap<EditContentBillModel, Bill>();

        #endregion

        #region Models to Contracts

        CreateMap<GetBrandModel, GetBrandsBrandDto>();
        CreateMap<CountryStatisticsBrandModel, GetCountriesStatisticsBrandDto>();
        CreateMap<CountryStatisticsCountryModel, GetCountriesStatisticsCountryDto>();
        CreateMap<MoneyStatisticsBrandModel, GetMoneyStatisticsBrandDto>();
        CreateMap<ContentStatisticsBrandModel, GetContentStatisticsBrandDto>();
        CreateMap<ContentStatisticsContentModel, GetContentStatisticsContentDto>();
        CreateMap<ContentStatisticsBillModel, GetContentStatisticsBillDto>();

        #endregion

        #region Models to Model

        CreateMap<BrandAdditionalInfoModel, GetBrandModel>();

        #endregion

        #region Entities to Models

        CreateMap<Brand, GetBrandModel>();

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