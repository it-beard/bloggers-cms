using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Pds.Web.Common
{
    public class CustomJSRuntimeCaller
    {
        private readonly IJSRuntime jsRuntime;

        public CustomJSRuntimeCaller(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task<bool> InvokeConfirm(string question)
        {
            return await jsRuntime.InvokeAsync<bool>("confirm", question);
        }

        public async Task InvokeHistoryBack()
        {
            await jsRuntime.InvokeVoidAsync("history.back");
        }
    }
}