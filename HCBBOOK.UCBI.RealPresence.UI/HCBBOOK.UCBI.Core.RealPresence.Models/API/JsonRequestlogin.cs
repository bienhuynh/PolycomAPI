using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCBBOOK.UCBI.Core.RealPresence.Models.API
{
    public class JsonRequestlogin
    {
        [Display(Name ="Username")]
        [StringLength(50), Required]
        public string userName { get; set; }

        [Display(Name = "Password")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 6), Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
