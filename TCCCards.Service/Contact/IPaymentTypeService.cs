using System.Collections.Generic;
using TCCCards.ViewModels.Payment;

namespace TCCCards.Service.Contact
{
    public interface IPaymentTypeService
    {
        List<PaymentTypeListViewModel> GetAll();
        PaymentTypeListViewModel GetById(int id);
    }
}
