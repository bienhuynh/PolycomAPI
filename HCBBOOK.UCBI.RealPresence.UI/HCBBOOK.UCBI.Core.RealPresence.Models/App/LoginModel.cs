using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HCBBOOK.UCBI.Core.RealPresence.Models.App
{
    public class LoginModel : API.JsonRequestlogin
    {
        [Display(Name = "Remember Cookie")]
        public bool RememberCookie { get; set; }
    }
}
