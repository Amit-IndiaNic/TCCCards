using System;
using TCCCards.ViewModels.Card;
using TCCCards.ViewModels.CustomerInfo;

namespace TCCCards.ViewModels.Payment
{
    public class OrderListViewModel
    {
        public CustomerListViewModel Customer { get; set; }
        public CardTemplateListViewModel Template { get; set; }
        public PaymentTypeListViewModel PaymentType { get; set; }
        public CardDetailListViewModel CardDetail { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; }
    }
}
