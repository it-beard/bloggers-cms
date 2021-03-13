using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using Pds.Api.Contracts.Person;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Pds.Web.Pages.Persons
{
    [Authorize]
    public class PersonsList : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        [Inject]
        public IAccessTokenProvider TokenProvider { get; set; }


        protected GetPersonsResponse personsInfo;
        protected readonly int pageSize = 5;

        protected override async Task OnInitializedAsync()
        {
            personsInfo = await GetPeople(pageSize, 0);
        }

        protected async Task Pagination(int pageOffset)
        {
            personsInfo = await GetPeople(pageSize, pageOffset);
        }

        private async Task<GetPersonsResponse> GetPeople(int pageSize, int pageOffset)
        {
            var backendApiUrl = Configuration["BackendApi:Url"];
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{backendApiUrl}/api/persons?limit={pageSize}&offset={pageOffset}");

            var result = new GetPersonsResponse();

            var tokenResult = await TokenProvider.RequestAccessToken();
            if (tokenResult.TryGetToken(out var token))
            {
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Value);
                //requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await Http.SendAsync(requestMessage);
                result = await response.Content.ReadFromJsonAsync<GetPersonsResponse>();
            }

            return result;
        }
    }
}
