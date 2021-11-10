using Microsoft.AspNetCore.Authentication.JwtBearer;
using Pds.Api.Authentication;
namespace Pds.Api.AppStart;

public static class AuthenticationExtensions
{
    private const string CorsPolicy = "PdsCorsPolicy";

    public static void AddCustomAuth0Authentication(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = configuration["Auth0:Authority"];
                options.Audience = configuration["Auth0:ApiIdentifier"];
            });

        var auth0Settings = new Auth0Settings();
        configuration.GetSection("Auth0").Bind(auth0Settings);
        services.AddSingleton(auth0Settings);
    }

    public static void AddCustomPdsCorsPolicy(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicy,
                builder => builder.WithOrigins(configuration.GetSection("AllowedOrigins").Get<List<string>>().ToArray())
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    }

    public static void UseCustomPdsCorsPolicy(this IApplicationBuilder app)
    {
        app.UseCors(CorsPolicy);
    }
}