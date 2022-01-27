global using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pds.Web;
using Pds.Web.Common;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddTransient<IApiClient, ApiClient>();
builder.Services.AddSingleton<StateContainer>();
builder.Services.AddSingleton<PageHistoryState>();
builder.Services.AddHeadElementHelper();
builder.Services.AddCustomAutoMapper();

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
});

await builder.Build().RunAsync();

