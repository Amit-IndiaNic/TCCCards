using System.Collections.Generic;
using TCCCards.ViewModels.CustomerInfo;

namespace TCCCards.Service.Contact
{
    public interface IAddressService
    {
        List<AddressListViewModel> GetAll();
        List<AddressListViewModel> GetByCustomerId(int customerId);
        AddEditAddressViewModel GetById(int id);
    }
}
