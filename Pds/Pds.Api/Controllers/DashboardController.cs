using Pds.Api.Contracts.Controllers.Dashboard.GetContentStatistics;
using Pds.Api.Contracts.Controllers.Dashboard.GetCountriesStatistics;
using Pds.Api.Contracts.Controllers.Dashboard.GetMoneyStatistics;
using Pds.Api.Contracts.Controllers.Dashboard.GetNearestDates;
using Pds.Services.Interfaces;

namespace Pds.Api.Controllers;

[Route("api/dashboard")]
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
    
    /// <summary>
    /// Return Money Statistics
    /// </summary>
    [HttpGet("money-statistics")]
    [ProducesResponseType(typeof(GetMoneyStatisticsResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMoneyStatistics()
    {
        try
        {
            var money = await dashboardService.GetMoneyStatisticsAsync();
            var response = mapper.Map<GetMoneyStatisticsResponse>(money);

            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
    
    /// <summary>
    /// Return Content Statistics
    /// </summary>
    [HttpGet("content-statistics")]
    [ProducesResponseType(typeof(GetContentStatisticsResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetContentStatistics()
    {
        try
        {
            var content = await dashboardService.GetContentStatisticsAsync();
            var response = mapper.Map<GetContentStatisticsResponse>(content);

            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
    
    /// <summary>
    /// Return Content Statistics
    /// </summary>
    [HttpGet("nearest-dates-for-default-brand")]
    [ProducesResponseType(typeof(GetNearestDatesResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetNearestDatesForDefaultBrand()
    {
        try
        {
            var nearestDateForNewEpisode = await dashboardService.GetNearestNewEpisodeDateForDefaultBrandAsync();
            var nearestIntegrationDate = await dashboardService.GetNearestIntegrationDateForDefaultBrandAsync();
            var response = new GetNearestDatesResponse
            {
                BrandName = nearestIntegrationDate.BrandName,
                NearestDateForNewEpisode = nearestDateForNewEpisode,
                NearestDateForIntegration = nearestIntegrationDate.Date,
                ContentIdForIntegration = nearestIntegrationDate.ContentId,
                ContentTitleForIntegration = nearestIntegrationDate.ContentTitle
            };

            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
}