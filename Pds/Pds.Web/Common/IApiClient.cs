using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Pds.Web.Common
{
    public interface IApiClient
    {
        Task<T> Get<T>(IAccessTokenProvider tokenProvider, string methodName) where T : class;
        Task<T> Post<T, U>(IAccessTokenProvider tokenProvider, string methodName, U payload) where T : class;
    }
}