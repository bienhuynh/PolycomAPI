using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCBBOOK.UCBI.RealPresence.UI.Controllers
{
    public class RoomsMeetingsController : Controller
    {
        /// <summary>
        /// Manage meeting room
        /// </summary>
        /// <returns>Return page manage Meeting room</returns>
        // GET: Rooms
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Create a new room meeting
        /// </summary>
        /// <returns>Return view form create room</returns>
        public ActionResult Create()
        {
            return View();
        }
        
    }
}