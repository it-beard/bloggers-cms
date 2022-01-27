using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pds.Api.Authentication;
using Pds.Api.Contracts;
using Pds.Api.Contracts.Brand;
using Pds.Api.Contracts.Gift;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models.Gift;

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
    /// Get gift by id
    /// </summary>
    /// <param name="giftId"></param>
    /// <returns></returns>
    [HttpGet("{giftId}")]
    [ProducesResponseType(typeof(GetGiftResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(Guid giftId)
    {
        try
        {
            var bill = await giftService.GetAsync(giftId);
            var response = mapper.Map<GetGiftResponse>(bill);

            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Return list of gifts
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("")]
    [ProducesResponseType(typeof(GetGiftsResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetGiftsRequest request)
    {
        try
        {
            var gifts = await giftService.GetAllAsync();

            var response = new GetGiftsResponse
            {
                Items = mapper.Map<List<GiftDto>>(gifts),
                Total = gifts.Count
            };

            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
    
    /// <summary>
    /// Create gift
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateGiftResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreateGiftRequest request)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var gift = mapper.Map<Gift>(request);
                var giftId = await giftService.CreateAsync(gift);
                return Ok(new CreateGiftResponse{Id = giftId});
            }

            return BadRequest();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
    
    /// <summary>
    /// Edit gift
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(typeof(EditGiftResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Edit(EditGiftRequest request)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest();
            var editGiftModel = mapper.Map<EditGiftModel>(request);
            var billId = await giftService.EditAsync(editGiftModel);
            return Ok(new EditGiftResponse{Id = billId});

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
            var brands = await brandService.GetAllForListsAsync();
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
    
    /// <summary>
    /// Complete specified gift
    /// </summary>
    /// <param name="giftId"></param>
    /// <returns></returns>
    [HttpPut("{giftId}/complete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Complete(Guid giftId)
    {
        try
        {
            await giftService.CompleteAsync(giftId);
            return Ok();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Uncomplete specified gift
    /// </summary>
    /// <param name="giftId"></param>
    /// <returns></returns>
    [HttpPut("{giftId}/uncomplete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Uncomplete(Guid giftId)
    {
        try
        {
            await giftService.UncompleteAsync(giftId);
            return Ok();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
    
    /// <summary>
    /// Delete specified gift
    /// </summary>
    /// <param name="giftId"></param>
    /// <returns></returns>
    [HttpDelete("{giftId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid giftId)
    {
        try
        {
            await giftService.DeleteAsync(giftId);
            return Ok();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
}