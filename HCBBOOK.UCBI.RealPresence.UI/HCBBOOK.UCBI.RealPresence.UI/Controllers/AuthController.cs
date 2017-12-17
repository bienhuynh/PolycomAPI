using HCBBOOK.UCBI.Core.RealPresence.MediaSuite;
using HCBBOOK.UCBI.Core.RealPresence.Models.API;
using HCBBOOK.UCBI.Core.RealPresence.Models.App;
using HCBBOOK.UCBI.RealPresence.UI.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HCBBOOK.UCBI.RealPresence.UI.Controllers
{
    [Authorize]
    public class AuthController : Controller
    {
        private string server = "record.ucbi-global.com";
        // GET: Auth
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            Authenticate authenticate = new Authenticate(server, login.userName, login.password);
            JsonResultLogin resultLogin = authenticate.CheckLogin();
            if (authenticate.isLogin)
            {
                FormsAuthentication.SetAuthCookie(login.userName, login.RememberCookie);
                
                return RedirectToAction("ControlRoomMeeting", "RoomsMeetings");
            }
            return View(login);
        }

        public new ActionResult Profile()
        {
            return View();
        }
        
        
        //User Lock Screen
        [Authorize]
        public ActionResult Lock(LoginModel login)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Auth");
        }

        //User Logout
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Auth");
        }

    }
}