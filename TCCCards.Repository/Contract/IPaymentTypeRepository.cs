using System.Linq;
using TCCCards.Models.Payment;
using TCCCards.Repository.Core;

namespace TCCCards.Repository.Contract
{
    public interface IPaymentTypeRepository : IBaseRepository<PaymentType>
    {
        //IQueryable<PaymentType> GetAllActive();
    }
}
