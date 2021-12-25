using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pds.Api.Authentication;
using Pds.Api.Contracts;
using Pds.Api.Contracts.Bill;
using Pds.Api.Contracts.Settings;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models.Bill;
namespace Pds.Api.Controllers;

[Route("api/settings")]
[CustomAuthorize]
public class SettingController : ApiControllerBase
{
    private readonly ILogger<PersonController> logger;
    private readonly IMapper mapper;
    private readonly ISettingService settingService;

    public SettingController(
        ILogger<PersonController> logger,
        IMapper mapper,
        ISettingService settingService)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.settingService = settingService;
    }
    
    /// <summary>
    /// Get settings
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(GetSettingsResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSettings()
    {
        try
        {
            var settings = await settingService.GetSettingsAsync();
            var response = mapper.Map<List<SettingDto>>(settings);
            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
}