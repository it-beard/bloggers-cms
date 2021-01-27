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
            services.AddAuth0Authentication(Configuration);
            services.AddPdsCorsPolicy(Configuration);
            services.AddControllers();
            services.AddCustomSwagger();
            services.AddSqlContext(Configuration);
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

            app.UsePdsCorsPolicy();
            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}