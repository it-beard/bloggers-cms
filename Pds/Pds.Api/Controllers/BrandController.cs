using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pds.Api.Authentication;
using Pds.Api.Contracts.Brand;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models.Brand;

namespace Pds.Api.Controllers;

[Route("api/brands")]
[CustomAuthorize]
public class BrandController : ApiControllerBase
{
    private readonly ILogger<ClientController> logger;
    private readonly IMapper mapper;
    private readonly IBrandService brandService;

    public BrandController(
        ILogger<ClientController> logger,
        IMapper mapper,
        IBrandService brandService)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.brandService = brandService;
    }

    /// <summary>
    /// Return list of brands
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(GetBrandsResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetBrandsRequest request)
    {
        try
        {
            var brands = await brandService.GetAllAsync();

            var response = new GetBrandsResponse
            {
                Items = mapper.Map<List<BrandFullDto>>(brands),
                Total = brands.Count
            };

            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
    
    /// <summary>
    /// Create a brand
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateBrandResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateBrandRequest request)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var newBrand = mapper.Map<Brand>(request);
                var brandId = await brandService.CreateAsync(newBrand);
                return Ok(new CreateBrandResponse{Id = brandId});
            }

            return BadRequest();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Get brand by id
    /// </summary>
    /// <param name="brandId"></param>
    /// <returns></returns>
    [HttpGet("{brandId}")]
    [ProducesResponseType(typeof(GetBrandResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(Guid brandId)
    {
        try
        {
            var brand = await brandService.GetAsync(brandId);
            var response = mapper.Map<GetBrandResponse>(brand);

            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
    
    /// <summary>
    /// Edit brand
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(typeof(EditBrandResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Edit(EditBrandRequest request)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var editBrandModel = mapper.Map<EditBrandModel>(request);
                var brandId = await brandService.EditAsync(editBrandModel);
                return Ok(new EditBrandResponse{Id = brandId});
            }

            return BadRequest();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
}