using Blazored.LocalStorage;

namespace Pds.Web.Common;

public static class LocalStorageFilterHelper<T>
{
    public static async Task<T> GetSavedFilterValues(T filter, ILocalStorageService localStorage, string savedSettingsLocalStorageKey)
    {
        var savedFilter = await localStorage.GetItemAsync<T>(savedSettingsLocalStorageKey);
        return savedFilter ?? filter;
    }
}