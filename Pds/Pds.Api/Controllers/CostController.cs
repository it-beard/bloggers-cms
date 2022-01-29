using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pds.Api.Authentication;
using Pds.Api.Contracts;
using Pds.Api.Contracts.Brand;
using Pds.Api.Contracts.Cost;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models.Cost;
namespace Pds.Api.Controllers;

[Route("api/costs")]
[CustomAuthorize]
public class CostController : ApiControllerBase
{
    private readonly ILogger<PersonController> logger;
    private readonly IMapper mapper;
    private readonly ICostService costService;
    private readonly IContentService contentService;
    private readonly IBrandService brandService;

    public CostController(
        ILogger<PersonController> logger,
        IMapper mapper,
        ICostService costService,
        IContentService contentService,
        IBrandService brandService)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.costService = costService;
        this.contentService = contentService;
        this.brandService = brandService;
    }

    /// <summary>
    /// Get cost by id
    /// </summary>
    /// <param name="costId"></param>
    /// <returns></returns>
    [HttpGet("{costId}")]
    [ProducesResponseType(typeof(GetCostResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(Guid costId)
    {
        try
        {
            var cost = await costService.GetAsync(costId);
            var response = mapper.Map<GetCostResponse>(cost);

            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Return list of costs
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(GetCostsResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetCostsRequest request)
    {
        try
        {
            var costs = await costService.GetAllAsync();

            var response = new GetCostsResponse
            {
                Items = mapper.Map<List<CostDto>>(costs),
                Total = costs.Count
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
    /// Return list of contents for lookup box by brand ID include already bound to cost content
    /// </summary>
    /// <param name="brandId"></param>
    /// <param name="costContentId"></param>
    /// <returns></returns>
    [HttpGet("get-contents/brands/{brandId}/content/{costContentId?}")]
    public async Task<IActionResult> GetContentsByBrandIdWithGiftContent(Guid brandId, Guid? costContentId)
    {
        try
        {
            var contents = await contentService.GetForListByBrandIdWithSelectedValueAsync(brandId, costContentId);
            var response = mapper.Map<List<ContentForLookupDto>>(contents);

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
    /// <param name="brandId"></param>
    /// <returns></returns>
    [HttpGet("get-contents/brands/{brandId}")]
    public async Task<IActionResult> GetContentsByBrandId(Guid brandId)
    {
        try
        {
            var contents = await contentService.GetForListByBrandIdAsync(brandId);
            var response = mapper.Map<List<ContentForLookupDto>>(contents);

            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Create cost
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateCostResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreateCostRequest request)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var newCost = mapper.Map<Cost>(request);
                var costId = await costService.CreateAsync(newCost);
                return Ok(new CreateCostResponse{Id = costId});
            }

            return BadRequest();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Edit cost
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(typeof(EditCostResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Edit(EditCostRequest request)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var editCostModel = mapper.Map<EditCostModel>(request);
                var costId = await costService.EditAsync(editCostModel);
                return Ok(new EditCostResponse{Id = costId});
            }

            return BadRequest();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Archive specified cost
    /// </summary>
    /// <param name="costId"></param>
    /// <returns></returns>
    [HttpPut("{costId}/archive")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Archive(Guid costId)
    {
        try
        {
            await costService.ArchiveAsync(costId);
            return Ok();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Unarchive specified cost
    /// </summary>
    /// <param name="costId"></param>
    /// <returns></returns>
    [HttpPut("{costId}/unarchive")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Unarchive(Guid costId)
    {
        try
        {
            await costService.UnarchiveAsync(costId);
            return Ok();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Delete specified cost
    /// </summary>
    /// <param name="costId"></param>
    /// <returns></returns>
    [HttpDelete("{costId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid costId)
    {
        try
        {
            await costService.DeleteAsync(costId);
            return Ok();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
}