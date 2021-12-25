namespace Pds.Api.Contracts.Settings;

public class GetSettingsResponse : List<SettingDto>
{
    public string GetByKey(string key)
    {
        var setting = this.First(s => s.Key == key);
        return setting == null? string.Empty : setting.Value;
    }
}