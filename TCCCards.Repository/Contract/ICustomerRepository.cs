using System.Linq;
using TCCCards.Models.CustomerInfo;
using TCCCards.Repository.Core;

namespace TCCCards.Repository.Contract
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        //IQueryable<Customer> GetAllActive();
    }

}
