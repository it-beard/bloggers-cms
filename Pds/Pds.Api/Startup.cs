using Autofac;
using Pds.Di;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pds.Api.AppStart;

namespace Pds.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomAuth0Authentication(Configuration);
            services.AddCustomPdsCorsPolicy(Configuration);
            services.AddControllers();
            services.AddCustomSwagger();
            services.AddCustomSqlContext(Configuration);
            services.AddCustomAutoMapper();
        }

        // Do not delete, this is initialization of DI
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ApiDiModule());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseCustomSwaggerUI();
            }

            app.UseCustomPdsCorsPolicy();
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}