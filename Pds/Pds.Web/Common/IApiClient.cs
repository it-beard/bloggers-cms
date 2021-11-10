using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
namespace Pds.Web.Common;

public interface IApiClient
{
    Task<T> Get<T>(IAccessTokenProvider tokenProvider, string methodName) where T : class, new();
    Task<T> Delete<T>(IAccessTokenProvider tokenProvider, string methodName) where T : class, new();
    Task<ApiResponse<T>> Post<T, U>(IAccessTokenProvider tokenProvider, string methodName, U payload) where T : class, new();
    Task<ApiResponse<T>> Put<T, U>(IAccessTokenProvider tokenProvider, string methodName, U payload) where T : class, new();
}