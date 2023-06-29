using Autofac;
using Autofac.Extensions.DependencyInjection;
using Pds.Api.AppStart;
using Pds.Di;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new ApiDiModule()));

//Add services
builder.Services.AddCustomAuth0Authentication(builder.Configuration);
builder.Services.AddCustomPdsCorsPolicy(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddCustomSwagger();
builder.Services.AddCustomSqlContext(builder.Configuration);
builder.Services.AddCustomAutoMapper();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseCustomSwaggerUI();
}

app.UseCustomPdsCorsPolicy();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
