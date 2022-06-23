namespace Pds.Api.Contracts.Controllers.Settings.GetSettings;

public class GetSettingsResponse : List<GetSettingsSettingDto>
{
    public string GetByKey(string key)
    {
        var setting = this.First(s => s.Key == key);
        return setting == null? string.Empty : setting.Value;
    }
}