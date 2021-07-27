using TCCCards.Models.CustomerInfo;
using TCCCards.Repository.Contract;
using TCCCards.Repository.Core;

namespace TCCCards.Repository.Implementation
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        //public CustomerRepository()
        //    : base()
        public CustomerRepository(DataContextFactory dataContextFactory)
            : base(dataContextFactory.GetDataContext(DataSourceType.Sql))
        {

        }

    }
}
