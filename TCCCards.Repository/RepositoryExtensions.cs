using Autofac;
using Autofac.Features.Indexed;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using TCCCards.Repository.Contract;
using TCCCards.Repository.Core;
using TCCCards.Repository.Data;
using TCCCards.Repository.Implementation;

namespace TCCCards.Repository
{
    public static class RepositoryExtensions
    {
        public static void AddRepositoryLayer(this ContainerBuilder services, IConfiguration configuration)
        {

            ILoggerFactory consoleLogFactory = LoggerFactory.Create(buillder => { buillder.AddConsole(); });


            services.Register(componentContext =>
            {
                // TODO : Getting Blank HttpContextAccessor
                var httpcontext = componentContext.Resolve<IHttpContextAccessor>();
                var connection = httpcontext.HttpContext.User.Claims.FirstOrDefault(t => t.Type == "ClientSQLConnect");
                string connectionString = connection?.Value ?? "";
                if (!string.IsNullOrEmpty(connectionString))
                {
                    var serviceProvider = componentContext.Resolve<IServiceProvider>();
                    var dbContextOptions = new DbContextOptionsBuilder<EFDataContext>();
                    dbContextOptions.UseSqlServer(connectionString);
                    dbContextOptions.UseLazyLoadingProxies();

                    dbContextOptions.UseLoggerFactory(consoleLogFactory);
                    dbContextOptions.EnableSensitiveDataLogging();
                    return new EFDataContext(dbContextOptions.Options);
                }
                return null;
            })
                //.As<IDataContext>()
                .Keyed<IDataContext>(DataSourceType.Sql)
            .InstancePerLifetimeScope()
                ;


            services.RegisterType<DataContextFactory>();

            services.Register(componentContext =>
            {
                var serviceProvider = componentContext.Resolve<IServiceProvider>();
                var dbIndex = serviceProvider.GetService<IIndex<DataSourceType, IDataContext>>();
                var dbContext = dbIndex[DataSourceType.Sql];
                return new UnitOfWork(dbContext);
            }).Keyed<IUnitOfWork>(DataSourceType.Sql);


            services.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            //services.RegisterType<CardDetailRepository>().As<ICardDetailRepository>();
            //services.RegisterType<CardTemplateRepository>().As<ICardTemplateRepository>();
            //services.RegisterType<OrderRepository>().As<IOrderRepository>();
            //services.RegisterType<AddressRepository>().As<IAddressRepository>();

            //services.RegisterType<PaymentTypeRepository>().As<IPaymentTypeRepository>();
            

        }
    }
}
