using System.Linq;
using TCCCards.Models.CustomerInfo;
using TCCCards.Repository.Core;

namespace TCCCards.Repository.Contract
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        //IQueryable<Address> GetAllActive();
    }
}
