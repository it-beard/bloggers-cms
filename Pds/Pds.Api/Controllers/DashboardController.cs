using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pds.Api.Authentication;
using Pds.Api.Contracts.Brand;
using Pds.Api.Contracts.Dashboard;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models.Brand;

namespace Pds.Api.Controllers;

[Route("api/dashboard")]
[CustomAuthorize]
public class DashboardController : ApiControllerBase
{
    private readonly ILogger<ClientController> logger;
    private readonly IMapper mapper;
    private readonly IDashboardService dashboardService;

    public DashboardController(
        ILogger<ClientController> logger,
        IMapper mapper,
        IDashboardService dashboardService)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.dashboardService = dashboardService;
    }

    /// <summary>
    /// Return Countries Statistics
    /// </summary>
    [HttpGet("countries-statistics")]
    [ProducesResponseType(typeof(GetCountriesStatisticsResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCountriesStatistics()
    {
        try
        {
            var statistics = await dashboardService.GetCountriesStatisticsAsync();
            var response = mapper.Map<GetCountriesStatisticsResponse>(statistics);

            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
}