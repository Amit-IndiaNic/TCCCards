using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCCards.ViewModels.Card
{
    public class AddEditCardViewModel
    {
        [Required]
        [StringLength(100)]
        public string NameOnCard { get; set; }
        //public string BankName { get; set; }
        //public string CardName { get; set; }

        [Required]
        [StringLength(1000)]
        public string ImagePath { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public DateTime ValidThrough { get; set; }

        [Required]
        public int CVV { get; set; }

        //public AddEditCardTemplateViewModel Template { get; set; }
    }

}
