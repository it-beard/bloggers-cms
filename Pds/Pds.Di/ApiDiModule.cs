using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Pds.Data;
using Pds.Data.Repositories;
using Pds.Data.Repositories.Interfaces;
using Module = Autofac.Module;

namespace Pds.Di
{
    public class ApiDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Pds.Data.AssemblyRunner.Run();
            Pds.Services.AssemblyRunner.Run();
            var assemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .OrderByDescending(a => a.FullName)
                .ToArray();

            ServicesRegister(ref builder, assemblies);
            RepositoriesRegister(ref builder, assemblies);
            UnitOfWorkRegister(ref builder);
            UnitOfWorkRegister(ref builder);
        }

        private void ServicesRegister(ref ContainerBuilder builder, Assembly[] assemblies)
        {
            var servicesAssembly = assemblies.FirstOrDefault(t => t.FullName.ToLower().Contains("pds.services"));
            builder.RegisterAssemblyTypes(servicesAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }

        private void RepositoriesRegister(ref ContainerBuilder builder, Assembly[] assemblies)
        {
            builder.RegisterGeneric(typeof(RepositoryBase<>))
                .As(typeof(IRepositoryBase<>));

            var dataAssembly = assemblies.FirstOrDefault(t => t.FullName.ToLower().Contains("pds.data"));
            builder.RegisterAssemblyTypes(dataAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
        }

        private void UnitOfWorkRegister(ref ContainerBuilder builder)
        {
            builder.RegisterType(typeof(UnitOfWork))
                .As(typeof(IUnitOfWork));
        }
    }
}