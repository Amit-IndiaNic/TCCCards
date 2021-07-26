using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCCards.Identity.Models
{
    public class LoginViewModel
    {
        public string ReturnUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public bool EnableLocalLogin { get; set; }
        public bool RememberLogin { get; set; }
    }
}
