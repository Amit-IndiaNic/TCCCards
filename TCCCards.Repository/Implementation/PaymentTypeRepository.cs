using TCCCards.Models.Payment;
using TCCCards.Repository.Contract;
using TCCCards.Repository.Core;

namespace TCCCards.Repository.Implementation
{
    public class PaymentTypeRepository : BaseRepository<PaymentType>, IPaymentTypeRepository
    {
        public PaymentTypeRepository(DataContextFactory dataContextFactory)
            : base(dataContextFactory.GetDataContext(DataSourceType.Sql))
        {

        }

    }
}
