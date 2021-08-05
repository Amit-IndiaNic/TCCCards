using Autofac.Features.Indexed;
using AutoMapper;
using TCCCards.Repository.Contract;
using TCCCards.Repository.Core;
using TCCCards.Repository.Data;
using TCCCards.Repository.Implementation;
using TCCCards.Service.Core;
using TCCCards.Service.Implementation;
using Xunit;

namespace UnitTestAPI
{
    public class CardTemplateServiceUnitTest
    {
        #region Variables

        public IIndex<DataSourceType, IDataContext> _dataContext;
        public DataContextFactory dataContextFactory;
        public ICardTemplateRepository ctr;
        public CardTemplateService cts;
        public IDataMapper dataMapper;
        public IMapper im;

        #endregion

        public CardTemplateServiceUnitTest()
        {
            dataContextFactory = new DataContextFactory(_dataContext);
            dataMapper = new AutomapperDataMapper(im);
            ctr = new CardTemplateRepository(dataContextFactory);
            cts = new CardTemplateService(ctr, dataMapper);
        }

        [Fact]
        public void TestGetAllCardTemplate()
        {
            Assert.NotNull(cts.GetAll());
        }

        [Fact]
        public void TestGetByIdCardTemplate()
        {
            Assert.NotNull(cts.GetById(1));
        }

        [Fact]
        public void TestGetByInvalidIdCardTemplate()
        {
            Assert.Null(cts.GetById(-1));
        }
    }
}
