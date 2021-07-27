using System.Linq;
using TCCCards.Models.Payment;
using TCCCards.Repository.Core;

namespace TCCCards.Repository.Contract
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        //IQueryable<Order> GetAllActive();
    }
}
