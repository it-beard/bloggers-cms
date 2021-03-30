using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pds.Api.AppStart
{
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
}