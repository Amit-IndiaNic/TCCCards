using System.Collections.Generic;
using TCCCards.ViewModels.CustomerInfo;

namespace TCCCards.Service.Contact
{
    public interface ICustomerService
    {
        List<CustomerListViewModel> GetAll();
        List<CustomerListViewModel> GetByUserId(int id);
        CustomerListViewModel GetById(int id);
        
        //AddEditCustomerViewModel GetById(int id);
        //int Insert(AddEditCustomerViewModel model, string userName);
        //int Update(AddEditCustomerViewModel model, string userName);
    }
}