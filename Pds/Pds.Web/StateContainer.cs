using Pds.Api.Contracts.Settings;

namespace Pds.Web;

public class StateContainer
{
    private GetSettingsResponse savedSettings;
    private bool savedIsContentFilterLoaded;

    public GetSettingsResponse Settings
    {
        get => savedSettings;
        set
        {
            savedSettings = value;
            NotifyStateChanged();
        }
    }
    
    public bool IsContentFilterLoaded
    {
        get => savedIsContentFilterLoaded;
        set
        {
            savedIsContentFilterLoaded = value;
            NotifyStateChanged();
        }
    }

    public event Action OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}