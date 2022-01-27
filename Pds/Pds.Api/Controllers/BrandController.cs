using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pds.Api.Authentication;
using Pds.Api.Contracts.Brand;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
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
}