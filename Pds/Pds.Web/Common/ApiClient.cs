using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Pds.Web.Common
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        public ApiClient(
            HttpClient httpClient, 
            IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }

        public async Task<T> Get<T>(IAccessTokenProvider tokenProvider, string methodName) where T : class, new()
        {
            return await CallGetOrDeleteRequest<T>(tokenProvider, methodName, HttpMethod.Get);
        }

        public async Task<T> Delete<T>(IAccessTokenProvider tokenProvider, string methodName) where T : class, new()
        {
            return await CallGetOrDeleteRequest<T>(tokenProvider, methodName, HttpMethod.Delete);
        }

        public async Task<T> Post<T, U>(IAccessTokenProvider tokenProvider, string methodName, U payload) where T : class, new()
        {
            return await CallPostOrPutRequest<T, U>(tokenProvider, methodName, payload, HttpMethod.Post);
        }
        
        public async Task<T> Put<T, U>(IAccessTokenProvider tokenProvider, string methodName, U payload) where T : class, new()
        {
            return await CallPostOrPutRequest<T, U>(tokenProvider, methodName, payload, HttpMethod.Put);
        }

        private async Task<T> CallGetOrDeleteRequest<T>(IAccessTokenProvider tokenProvider, string methodName, HttpMethod method) where T : class, new()
        {
            var backendApiUrl = configuration["BackendApi:Url"];
            using var requestMessage = new HttpRequestMessage(method, $"{backendApiUrl}/api/{methodName}");
            var tokenResult = await tokenProvider.RequestAccessToken();

            if (tokenResult.TryGetToken(out var token)) {
                requestMessage.Headers.Authorization = 
                    new AuthenticationHeaderValue("Bearer", token.Value);
                var response = await httpClient.SendAsync(requestMessage);
                return 
                    await response.Content.ReadAsStringAsync() == string.Empty ? 
                        new T() : 
                        await response.Content.ReadFromJsonAsync<T>();
            }

            throw new TokenException();
        }

        private async Task<T> CallPostOrPutRequest<T, U>(IAccessTokenProvider tokenProvider, string methodName, U payload, HttpMethod method) where T : class, new()
        {
            
            var backendApiUrl = configuration["BackendApi:Url"];
            using var requestMessage = new HttpRequestMessage(method, $"{backendApiUrl}/api/{methodName}")
            {
                Content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload)))
            };

            var tokenResult = await tokenProvider.RequestAccessToken();
            if (tokenResult.TryGetToken(out var token))
            {
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Value);
                requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await httpClient.SendAsync(requestMessage);
                return 
                    await response.Content.ReadAsStringAsync() == string.Empty ? 
                        new T() : 
                        await response.Content.ReadFromJsonAsync<T>();
            }

            throw new TokenException();
        }
    }
}