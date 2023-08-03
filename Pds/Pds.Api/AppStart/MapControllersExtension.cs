using Pds.Api.Authentication;

namespace Pds.Api.AppStart;

public static class MapControllersExtension
{
    public static ControllerActionEndpointConventionBuilder  MapCustomControllers(this WebApplication app, Auth0Settings auth0Settings)
    {
        var endpointBuilder = app.MapControllers();

        if (auth0Settings.Enabled)
        {
            endpointBuilder.RequireAuthorization();
        }
        
        return endpointBuilder;
    }
}