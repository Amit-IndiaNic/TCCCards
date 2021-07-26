using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCCards.Models.CustomerInfo
{
    [Table("Addresses")]
    public class Address : BaseStatusEntity
    {
        [Required]
        [StringLength(500)]
        public string Address1 { get; set; }

        [StringLength(500)]
        public string Address2 { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [StringLength(10)]
        public string PinCode { get; set; }

        public Customer Customer { get; set; }
    }
}
