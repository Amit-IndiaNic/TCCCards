using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCCards.ViewModels.Card
{
    public class CardDetailListViewModel
    {
        public string NameOnCard { get; set; }
        public string BankName { get; set; }
        public string CardName { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }

        public string CardNumber { get; set; }
        public DateTime ValidThrough { get; set; }
        public int CVV { get; set; }
    }
}
