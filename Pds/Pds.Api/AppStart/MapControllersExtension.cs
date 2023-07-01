using Pds.Api.Authentication;

namespace Pds.Api.AppStart;

public static class MapControllersExtension
{
    public static void MapCustomControllers(this WebApplication app, IConfiguration configuration)
    {
        var auth0Settings = new Auth0Settings();
        configuration.GetSection("Auth0").Bind(auth0Settings);

        if (auth0Settings.Enabled)
        {
            app.MapControllers();
        }
        else
        {
            app.MapControllers().AllowAnonymous();
        }
    }
}