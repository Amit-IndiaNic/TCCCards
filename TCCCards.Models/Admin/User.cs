using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TCCCards.Models.CustomerInfo;

namespace TCCCards.Models
{
    public class User : BaseStatusEntity
    {
        [Required]
        [StringLength(100)]
        public string EmailId { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}

