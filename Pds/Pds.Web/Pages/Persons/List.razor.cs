using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using Pds.Api.Contracts.Person;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Pds.Web.Pages.Persons
{
    //[Authorize]
    public class ListBase : ComponentBase
    {

        [Inject] 
        public HttpClient Http { get; set; }
        [Inject] 
        public IConfiguration Configuration { get; set; }
        [Inject] 
        public IAccessTokenProvider TokenProvider { get; set; }


        protected GetPersonsResponse personsInfo;
        private readonly int pageSize = 2;
        private int pageOffset = 0;
        private int pageTotal = 2;

        protected override async Task OnInitializedAsync()
        {
            personsInfo = await GetPeople(pageSize, pageOffset);
            pageTotal = personsInfo.Total;
        }

        protected async Task Next()
        {
            pageOffset = Math.Min(pageOffset + pageSize, pageTotal);
            personsInfo = await GetPeople(pageSize, pageOffset);
        }

        protected async Task Previous()
        {
            pageOffset = Math.Max(pageOffset - pageSize, 0);
            personsInfo = await GetPeople(pageSize, pageOffset);
        }

        private async Task<GetPersonsResponse> GetPeople(int pageSize, int pageOffset)
        {
            var backendApiUrl = Configuration["BackendApi:Url"];
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{backendApiUrl}/api/persons?limit={pageSize}&offset={pageOffset}");

            var response = await Http.SendAsync(requestMessage);
            return await response.Content.ReadFromJsonAsync<GetPersonsResponse>();
        }
    }
}
