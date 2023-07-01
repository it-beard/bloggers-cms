using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
namespace Pds.Web.Common.FakeAuthorisation;

public class FakeAuthenticationStateProvider : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, "User"),
            new Claim(ClaimTypes.Email, "testuser@example.com"),
            new Claim(ClaimTypes.Role, "fake")
        }, "Bearer");

        var user = new ClaimsPrincipal(identity);
        return await Task.FromResult(new AuthenticationState(user));
    }
}