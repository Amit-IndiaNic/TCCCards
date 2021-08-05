using Autofac.Features.Indexed;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Collections.Generic;
using TCCCards.Repository.Contract;
using TCCCards.Repository.Core;
using TCCCards.Repository.Data;
using TCCCards.Repository.Implementation;
using TCCCards.Service.Core;
using TCCCards.Service.Implementation;
using TCCCards.ViewModels.Card;
using Xunit;

namespace UnitTestAPI
{
    public class DbFixture
    {
        public DbFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection
                .AddDbContext<EFDataContext>(options => options.UseSqlServer("Data Source = DELL; Initial Catalog = TCCCardsDB; Integrated Security = True;"),
                    ServiceLifetime.Transient);

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }


    public class CardDetailServiceUnitTest : IClassFixture<DbFixture>
    {

        #region Variables


        private ServiceProvider _serviceProvider;
        public IIndex<DataSourceType, IDataContext> _dataContext;
        public DataContextFactory dataContextFactory;
        public ICardDetailRepository cdr;
        public CardDetailService cds;
        public IDataMapper dataMapper;
        public IIndex<DataSourceType, IUnitOfWork> uow;
        public IMapper im;
        #endregion

        public CardDetailServiceUnitTest(DbFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            dataContextFactory = new DataContextFactory(_dataContext);
            dataMapper = new AutomapperDataMapper(im);
            cdr = new CardDetailRepository(dataContextFactory);
            cds = new CardDetailService(cdr,dataMapper, uow);
        }
        

        [Fact]
        public void TestGetAllCardDetails()
        {
            Assert.NotNull(cds.GetAll());
        }

        [Fact]
        public void TestGetByCustomerIdCardDetails()
        {
            Assert.NotNull(cds.GetByCustomerId(1));
        }

        [Fact]
        public void TestGetByInvalidCustomerIdCardDetails()
        {
            Assert.Null(cds.GetByCustomerId(-1));
        }

        [Fact]
        public void TestGetByIdCardDetails()
        {
            Assert.NotNull(cds.GetById(1));
        }

        [Fact]
        public void TestGetByInvalidIdCardDetails()
        {
            Assert.Null(cds.GetById(-1));
        }

    }
}
