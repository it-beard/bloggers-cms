using Autofac;
using Autofac.Extensions.DependencyInjection;
using Pds.Api.AppStart;
using Pds.Api.Authentication;
using Pds.Di;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new ApiDiModule()));

//Add services
var auth0Settings = builder.Configuration.GetSection(Auth0Settings.ConfigSectionPath).Get<Auth0Settings>();
builder.Services.AddCustomAuthentication(auth0Settings);
builder.Services.AddCustomAuthorization(auth0Settings);

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


// each controller has own/explicit Route attribute and is not covered by MapControllerRoute
var endpointBuilder = app.MapControllers();
if (auth0Settings.Enabled)
{
    endpointBuilder.RequireAuthorization();
}

app.Run();
