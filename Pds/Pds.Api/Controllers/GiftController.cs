using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pds.Api.Authentication;
using Pds.Api.Contracts;
using Pds.Api.Contracts.Bill;
using Pds.Api.Contracts.Gift;
using Pds.Services.Interfaces;

namespace Pds.Api.Controllers;

[Route("api/gifts")]
[CustomAuthorize]
public class GiftController : ApiControllerBase
{
    private readonly ILogger<PersonController> logger;
    private readonly IMapper mapper;
    private readonly IGiftService giftService;
    private readonly IBrandService brandService;
    private readonly IContentService contentService;

    public GiftController(
        ILogger<PersonController> logger,
        IMapper mapper,
        IGiftService giftService,
        IBrandService brandService,
        IContentService contentService)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.giftService = giftService;
        this.brandService = brandService;
        this.contentService = contentService;
    }

    /// <summary>
    /// Return list of bills
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("")]
    [ProducesResponseType(typeof(GetBillsResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetBillsRequest request)
    {
        try
        {
            var paidBills = await giftService.GetAllAsync();

            var response = new GetGiftsResponse
            {
                Items = mapper.Map<List<GiftDto>>(paidBills),
                Total = paidBills.Count
            };

            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
    
    /// <summary>
    /// Return list of brands for checkboxes group
    /// </summary>
    [HttpGet]
    [Route("get-brands")]
    public async Task<IActionResult> GetListOfBrands()
    {
        try
        {
            var brands = await brandService.GetBrandsForListsAsync();
            var response = mapper.Map<List<BrandDto>>(brands);

            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Return list of contents for lookup box
    /// </summary>
    [HttpGet]
    [Route("get-contents")]
    public async Task<IActionResult> GetListOfContents()
    {
        try
        {
            var contents = await contentService.GetContentsForListsAsync();
            var response = mapper.Map<List<ContentForLookupDto>>(contents);

            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
}