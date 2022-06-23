namespace Pds.Api.Contracts.Controllers.Settings.GetSettings;

public class GetSettingsSettingDto : IActionsSetting
{
    public Guid Id { get; set; }
    public string Key { get; set; }
    
    public string Value { get; set; }
    
    public string Description { get; set; }
}