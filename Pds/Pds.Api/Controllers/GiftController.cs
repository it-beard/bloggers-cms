using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pds.Api.Authentication;
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
    private readonly IClientService clientService;

    public GiftController(
        ILogger<PersonController> logger,
        IMapper mapper,
        IGiftService giftService,
        IBrandService brandService,
        IClientService clientService)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.giftService = giftService;
        this.brandService = brandService;
        this.clientService = clientService;
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
}