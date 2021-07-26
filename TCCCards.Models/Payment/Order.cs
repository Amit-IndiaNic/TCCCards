using System;
using System.ComponentModel.DataAnnotations.Schema;
using TCCCards.Models.Card;
using TCCCards.Models.CustomerInfo;

namespace TCCCards.Models.Payment
{
    [Table("Orders")]
    public class Order : BaseStatusEntity
    {
        
        public Customer Customer { get; set; }
        public CardTemplate Template { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; }

    }
}
