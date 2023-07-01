using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Pds.Web.Common.FakeAuthorisation;

namespace Pds.Web.Common.AppStart;

public static class AuthenticationExtensions
{
    public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var isAuth0Enabled = configuration.GetValue<bool>("Auth0:Enabled");
        if(!isAuth0Enabled)
        {
            services.AddScoped<AuthenticationStateProvider, FakeAuthenticationStateProvider>();
            services.AddSingleton<IAuthorizationPolicyProvider, DefaultAuthorizationPolicyProvider>();
            services.AddScoped<IAccessTokenProvider, FakeAccessTokenProvider>();
            services.AddAuthorizationCore();
        }
        else
        {
            services.AddOidcAuthentication(options =>
            {
                configuration.Bind("Auth0", options.ProviderOptions);
                options.ProviderOptions.ResponseType = "code";
            });
        }
    }
}