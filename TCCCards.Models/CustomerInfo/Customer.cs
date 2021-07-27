using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TCCCards.Models.Card;

namespace TCCCards.Models.CustomerInfo
{
    public class Customer : BaseStatusEntity
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        public User User { get; set; }

        public virtual ICollection<CardDetail> CardDetails { get; set; } = new List<CardDetail>();
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    }
}
