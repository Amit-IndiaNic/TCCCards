using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCCards.Models.Payment
{
    [Table("PaymentTypes")]
    public class PaymentType : BaseStatusEntity
    {
        [Required]
        [StringLength(100)]
        public string Type { get; set; }

    }
}