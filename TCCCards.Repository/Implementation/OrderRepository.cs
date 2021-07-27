using TCCCards.Models.Payment;
using TCCCards.Repository.Contract;
using TCCCards.Repository.Core;

namespace TCCCards.Repository.Implementation
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DataContextFactory dataContextFactory)
            : base(dataContextFactory.GetDataContext(DataSourceType.Sql))
        {

        }

    }
}
