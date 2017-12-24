using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCBBOOK.UCBI.RealPresence.UI.Controllers
{
    public class UserMeetingsController : Controller
    {
        // GET: UserMeetings
        public ActionResult Index()
        {
            return View();
        }

        public bool MuteMic()
        {
            return true;
        }

        /// <summary>
        /// All participants are unmuted.
        /// </summary>
        /// <param name="conferenceId"></param>
        /// <returns></returns>
        public bool UnmuteAll(string conferenceId)
        {
            return true;
        }

        /// <summary>
        /// All participants are muted except for the list of participant identifiers passed in.
        /// </summary>
        /// <param name="conferenceId"></param>
        /// <returns></returns>
        public bool MuteAllExcept(string conferenceId)
        {
            return true;
        }

        
    }
}