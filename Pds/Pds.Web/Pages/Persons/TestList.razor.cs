using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using Pds.Api.Contracts.Person;
using Pds.Api.Contracts.Paging;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Pds.Web.Components;
using Newtonsoft.Json;
using System.Text;

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
        protected readonly int[] pageSizesList = { 5, 10, 25, 50 };
        private int pageSize;
        private int pageOffset;

        protected override async Task OnInitializedAsync()
        {
            pageSize = pageSizesList[0];
            personsInfo = await GetPeople(pageSize, pageOffset);
        }

        protected async Task Pagination(PaginationSettings paggingSettings)
        {
            pageOffset = paggingSettings.PageOffSet;
            pageSize = paggingSettings.PageSize;
            personsInfo = await GetPeople(pageSize, pageOffset);
        }

        private async Task<GetPersonsResponse> GetPeople(int pageSize, int pageOffset)
        {
            var backendApiUrl = Configuration["BackendApi:Url"];
            //using var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{backendApiUrl}/api/persons?limit={pageSize}&offset={pageOffset}");

            var requestBody = new GetPersonsRequest()
            {
                PageSettings = new PageSettings() { Limit = pageSize, Offset = pageOffset },
                OrderSettings = new OrderSetting<PersonsFieldName>[] { 
                new OrderSetting<PersonsFieldName>{Ascending = true, FieldName = PersonsFieldName.FullName}    
                },
                FilterSettings = new FilterSettings() { Search = ""}
            };
            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{backendApiUrl}/api/persons/search") 
            {
                Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json")
            };

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
