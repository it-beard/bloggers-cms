using Pds.Api.Contracts.Controllers.Brand.CreateBrand;
using Pds.Api.Contracts.Controllers.Brand.EditBrand;
using Pds.Api.Contracts.Controllers.Brand.GetBrand;
using Pds.Api.Contracts.Controllers.Brand.GetBrands;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models.Brand;

namespace Pds.Api.Controllers;

[Route("api/brands")]
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
                Items = mapper.Map<List<GetBrandsBrandDto>>(brands),
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
    
    /// <summary>
    /// Delete specified brand
    /// </summary>
    /// <param name="brandId"></param>
    /// <returns></returns>
    [HttpDelete("{brandId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid brandId)
    {
        try
        {
            await brandService.DeleteAsync(brandId);
            return Ok();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
    /// <summary>
    /// Make brand as a brand by default
    /// </summary>
    /// <param name="brandId"></param>
    /// <returns></returns>
    [HttpPut("{brandId}/default")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> MakeDefault(Guid brandId)
    {
        try
        {
            await brandService.MakeDefaultAsync(brandId);
            return Ok();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
    
    /// <summary>
    /// Archive specified brand
    /// </summary>
    /// <param name="brandId"></param>
    /// <returns></returns>
    [HttpPut("{brandId}/archive")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Archive(Guid brandId)
    {
        try
        {
            await brandService.ArchiveAsync(brandId);
            return Ok();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Unarchive specified brand
    /// </summary>
    /// <param name="brandId"></param>
    /// <returns></returns>
    [HttpPut("{brandId}/unarchive")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Unarchive(Guid brandId)
    {
        try
        {
            await brandService.UnarchiveAsync(brandId);
            return Ok();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
}