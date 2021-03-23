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
        public async Task<T> Get<T>(IAccessTokenProvider tokenProvider, string methodName) where T : class
        {
            var backendApiUrl = configuration["BackendApi:Url"];
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{backendApiUrl}/api/{methodName}");
            var tokenResult = await tokenProvider.RequestAccessToken();

            if (tokenResult.TryGetToken(out var token)) {
                requestMessage.Headers.Authorization = 
                    new AuthenticationHeaderValue("Bearer", token.Value);
                var response = await httpClient.SendAsync(requestMessage);
                return await response.Content.ReadFromJsonAsync<T>();
            }

            throw new TokenException();
        }
        
        public async Task<T> Post<T, U>(IAccessTokenProvider tokenProvider, string methodName, U payload) where T : class
        {
            var backendApiUrl = configuration["BackendApi:Url"];
            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{backendApiUrl}/api/{methodName}")
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
                return await response.Content.ReadFromJsonAsync<T>();
            }

            throw new TokenException();
        }
    }
}