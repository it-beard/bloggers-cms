using Microsoft.AspNetCore.Authentication.JwtBearer;
using Pds.Api.Authentication;
namespace Pds.Api.AppStart;

public static class AuthenticationExtensions
{
    private const string CorsPolicy = "PdsCorsPolicy";

    public static void AddCustomAuthentication(this IServiceCollection services, Auth0Settings configuration)
    {
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearerOptions =>
            {
                bearerOptions.Authority = configuration.Authority;
                bearerOptions.Audience = configuration.ApiIdentifier;
            });
    }
    
    public static void AddCustomAuthorization(this IServiceCollection services, Auth0Settings configuration)
    {
        services.AddAuthorization(options =>
        {
            options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("azp", configuration.AllowedAppId)
                .Build();
        });
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