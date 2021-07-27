using System;
using TCCCards.ViewModels.Card;
using TCCCards.ViewModels.CustomerInfo;

namespace TCCCards.ViewModels.Payment
{
    public class AddEditOrderViewModel
    {
        public AddEditCustomerViewModel Customer { get; set; }
        public AddEditCardTemplateViewModel Template { get; set; }
        public AddEditPaymentTypeViewModel PaymentType { get; set; }
        public AddEditCardDetailViewModel CardDetail { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; }
    }
}
