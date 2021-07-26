using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TCCCards.Models.CustomerInfo;

namespace TCCCards.Models.Card
{
    [Table("CardDetails")]
    public class CardDetail : BaseStatusEntity
    {
        [Required]
        [StringLength(100)]
        public string NameOnCard { get; set; }
        //public string BankName { get; set; }
        //public string CardName { get; set; }

         [Required]
        [StringLength(16)]
        public string CardNumber { get; set; }
        
        [Required]
        public DateTime ValidThrough { get; set; }
        
        [Column(TypeName = "Varchar(3)")]
        [Required]
        public int CVV { get; set; }

        public CardTemplate Template { get; set; }
        public Customer Customer { get; set; }
    }
}