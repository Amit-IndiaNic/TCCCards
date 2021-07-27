using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace TCCCards.ViewModels.Card
{
    public class AddEditCardDetailViewModel
    {
        public string NameOnCard { get; set; }
        //public string BankName { get; set; }
        //public string CardName { get; set; }

        public string ImagePath { get; set; }

        public IFormFile Image { get; set; }

        public string CardNumber { get; set; }

        public DateTime ValidThrough { get; set; }

        public int CVV { get; set; }

        //public AddEditCardTemplateViewModel Template { get; set; }
    }
}
