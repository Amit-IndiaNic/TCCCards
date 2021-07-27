using Autofac;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Linq;
using TCCCards.Repository;
using TCCCards.Service.Contact;
using TCCCards.Service.Core;
using TCCCards.Service.Profile;

namespace TCCCards.Service
{
    public static class ServiceLayerExtension
    {
        public static void AddServiceLayer(this ContainerBuilder services, IConfiguration configuration)
        {
            services.AddRepositoryLayer(configuration);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomerMappingProfile>();
            });

            var mapper = new Mapper(config);

            services.RegisterType<AutomapperDataMapper>().As<IDataMapper>()
                .WithParameter(new NamedParameter("mapper", mapper))
                .InstancePerLifetimeScope()
                ;

            var servicesToRegister = typeof(ICustomerService).Assembly.GetTypes()
                .Where(s => s.Name.EndsWith("Service") && !s.IsInterface
                && !s.IsAbstract
                ).ToArray();

            services.RegisterTypes(servicesToRegister).AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}
