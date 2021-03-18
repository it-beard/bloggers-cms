using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Pds.Api.Contracts.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pds.Web.Pages.Persons
{
    [Authorize]
    public class CreateBase : ComponentBase
    {
        [Inject] public HttpClient HttpClient { get; set; }
        [Inject] public IConfiguration Configuration { get; set; }
        [Inject] public IAccessTokenProvider TokenProvider { get; set; }
        [Inject] public NavigationManager NavigationManager{ get; set; }

        protected readonly CreatePersonRequest person = new()
        {
            Rate = 0,
            Resources = new List<ResourceDto> { }
        };
        protected EditContext editContext;

        protected override void OnInitialized()
        {
            editContext = new EditContext(person);
        }

        protected async Task HandleSubmit()
        {
            var isValid = editContext.Validate();

            if (isValid)
            {
                var backendApiUrl = Configuration["BackendApi:Url"];
                using var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{backendApiUrl}/api/persons")
                {
                    Content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(person)))
                };

                var tokenResult = await TokenProvider.RequestAccessToken();
                if (tokenResult.TryGetToken(out var token))
                {
                    requestMessage.Headers.Authorization =
                        new AuthenticationHeaderValue("Bearer", token.Value);
                    requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    await HttpClient.SendAsync(requestMessage);
                    NavigationManager.NavigateTo("/persons");
                }

                //requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //await HttpClient.SendAsync(requestMessage);
                //NavigationManager.NavigateTo("/persons");

            }
        }

        protected void AddResource()
        {
            var resource = new ResourceDto();
            person.Resources.Add(resource);
        }

        protected void RemoveResource(ResourceDto resource)
        {
            person.Resources.Remove(resource);
        }
    }
}
