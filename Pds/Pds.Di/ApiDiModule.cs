using System.Reflection;
using Autofac;
using Pds.Data;
using Pds.Data.Repositories;
using Pds.Data.Repositories.Interfaces;
using Module = Autofac.Module;
namespace Pds.Di;

public class ApiDiModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        ServicesRegister(builder);
        RepositoriesRegister(builder);
        UnitOfWorkRegister(builder);
    }

    private void ServicesRegister(ContainerBuilder builder)
    {
        var servicesAssembly = typeof(Services.AssemblyRunner).Assembly;
        builder.RegisterAssemblyTypes(servicesAssembly)
            .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces();
    }

    private void RepositoriesRegister(ContainerBuilder builder)
    {
        var dataAssembly = typeof(Pds.Data.AssemblyRunner).Assembly;
        builder.RegisterAssemblyTypes(dataAssembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces();
    }
        
    private void UnitOfWorkRegister(ContainerBuilder builder)
    {
        builder.RegisterType(typeof(UnitOfWork))
            .As(typeof(IUnitOfWork));
    }
}