using System.Collections.Generic;
using TCCCards.ViewModels.Payment;

namespace TCCCards.Service.Contact
{
    public interface IOrderService
    {
        List<OrderListViewModel> GetAll();
        List<OrderListViewModel> GetByCustomerId(int customerId);
        AddEditOrderViewModel GetById(int id);
        int Insert(AddEditOrderViewModel model, string userName);
        int Update(AddEditOrderViewModel model, string userName);
    }
}
