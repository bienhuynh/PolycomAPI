using HCBBOOK.UCBI.Core.RealPresence.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCBBOOK.UCBI.Core.RealPresence.MediaSuite
{
    interface IAuthenticate
    {
        string GetUsername();
        void SetUsername(string value);
        string GetPassword();
        void SetPassword(string value);
        JsonResultLogin CheckLogin();
    }
}
