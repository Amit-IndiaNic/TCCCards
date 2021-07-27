using TCCCards.Models.CustomerInfo;
using TCCCards.Repository.Contract;
using TCCCards.Repository.Core;

namespace TCCCards.Repository.Implementation
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(DataContextFactory dataContextFactory)
            : base(dataContextFactory.GetDataContext(DataSourceType.Sql))
        {

        }

    }
}
