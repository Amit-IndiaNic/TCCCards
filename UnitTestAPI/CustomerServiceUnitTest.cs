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
    public class CustomerServiceUnitTest
    {
        #region Variables

        public IIndex<DataSourceType, IDataContext> _dataContext;
        public DataContextFactory dataContextFactory;
        public ICustomerRepository cr;
        public CustomerService cs;
        public IDataMapper dataMapper;
        public IMapper im;

        #endregion

        public CustomerServiceUnitTest()
        {
            dataContextFactory = new DataContextFactory(_dataContext);
            dataMapper = new AutomapperDataMapper(im);
            cr = new CustomerRepository(dataContextFactory);
            cs = new CustomerService(cr, dataMapper);
        }

        [Fact]
        public void TestGetAllCustomer()
        {
            Assert.NotNull(cs.GetAll());
        }

        [Fact]
        public void TestGetByCustomerIdCustomer()
        {
            Assert.NotNull(cs.GetByUserId(1));
        }

        [Fact]
        public void TestGetByInvalidCustomerIdCustomer()
        {
            Assert.Null(cs.GetByUserId(-1));
        }

        [Fact]
        public void TestGetByIdCustomer()
        {
            Assert.NotNull(cs.GetById(1));
        }

        [Fact]
        public void TestGetByInvalidIdCustomer()
        {
            Assert.Null(cs.GetById(-1));
        }
    }
}