using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pds.Api.Authentication;
using Pds.Api.Contracts;
using Pds.Api.Contracts.Controllers.Client.EditClient;
using Pds.Api.Contracts.Controllers.Settings.EditSetting;
using Pds.Api.Contracts.Controllers.Settings.GetSetting;
using Pds.Api.Contracts.Controllers.Settings.GetSettings;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models.Bill;
using Pds.Services.Models.Setting;

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
    /// Get setting by id
    /// </summary>
    /// <param name="settingId"></param>
    /// <returns></returns>
    [HttpGet("{settingId}")]
    [ProducesResponseType(typeof(GetSettingResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(Guid settingId)
    {
        try
        {
            var setting = await settingService.GetAsync(settingId);
            var response = mapper.Map<GetSettingResponse>(setting);

            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
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
            var settings = await settingService.GetAllAsync();
            var response = mapper.Map<List<GetSettingsSettingDto>>(settings);
            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
    
    /// <summary>
    /// Edit setting
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(typeof(EditSettingResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Edit(EditSettingRequest request)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var editSettingModel = mapper.Map<EditSettingModel>(request);
                var settingId = await settingService.EditAsync(editSettingModel);
                return Ok(new EditClientResponse{Id = settingId});
            }

            return BadRequest();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
}