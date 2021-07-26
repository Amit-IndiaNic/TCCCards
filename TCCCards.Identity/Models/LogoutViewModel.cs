using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCCards.Identity.Models
{
    public class LogoutViewModel : LogoutInputModel
    {
        public bool ShowLogoutPrompt { get; set; } = true;
    }

    public class LogoutInputModel
    {
        public string LogoutId { get; set; }
    }
}
