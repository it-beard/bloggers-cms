using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace Pds.Web.Common
{
    public class ApiResponse<T>
    {
        public ApiResponse(HttpResponseMessage response, string rawPayload)
        {
            IsSuccessStatusCode = response.IsSuccessStatusCode;
            Code = response.StatusCode;
            RawPayload = rawPayload;
        }

        public HttpStatusCode Code { get; }

        public bool IsSuccessStatusCode { get; }

        public string RawPayload { get;}

        public T Payload { get; set; }

        public void AddErrors(ValidationMessageStore msgStore, EditContext editContext)
        {
            var errors = JsonConvert.DeserializeObject<List<string>>(RawPayload);
            foreach (var error in errors)
            {
                msgStore.Add(editContext.Field(string.Empty), error);
            }
            editContext.NotifyValidationStateChanged();
        }
    }
}