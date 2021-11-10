using Microsoft.EntityFrameworkCore;
using Pds.Data;
namespace Pds.Api.AppStart;

public static class DatabaseContextExtensions
{
    public static void AddCustomSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connectionString));
        services.BuildServiceProvider().GetService<ApplicationDbContext>().Database.Migrate(); // DB automigration on start enable
    }
}