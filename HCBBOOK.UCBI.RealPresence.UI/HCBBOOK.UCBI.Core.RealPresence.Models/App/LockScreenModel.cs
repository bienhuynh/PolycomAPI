using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCBBOOK.UCBI.Core.RealPresence.Models.App
{
    public class LockScreenModel
    {
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Display(Name = "Password")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 6), Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
