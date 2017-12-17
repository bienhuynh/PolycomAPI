using HCBBOOK.UCBI.Core.RealPresence.GenaralService;
using HCBBOOK.UCBI.Core.RealPresence.MediaSuite;
using HCBBOOK.UCBI.Core.RealPresence.Models.API;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
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
        public ActionResult AllConference()
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

        /// <summary>
        /// View page table control room meeting
        /// </summary>
        /// <returns></returns>
        public ActionResult ControlRoomMeeting()
        {
            Authenticate auth = new Authenticate("record.ucbi-global.com", "admin", "Polycom!23");
            JsonResultLogin resultToken = auth.CheckLogin();
            MyHttpRequest myHttpRequest = new MyHttpRequest();
            string res = myHttpRequest.HttpPostRequestWithToken(
                "https://rm.vnmeeting.com:8443/api/rest/conferences",
                null,
                resultToken.Token,
                "application/vnd.plcm.plcm-conference-list+json",
                "application/vnd.plcm.plcm-conference-list+json"
                );
            string url = "https://rm.vnmeeting.com:8443/api/rest/conferences";
            string username = "admin";
            string password = "Polycom!23";
            var client = new RestClient
            {
                BaseUrl = new Uri(url),
                Authenticator = new HttpBasicAuthenticator(username, password)
            };
            //var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cache-Control", "no-cache");
            //request.AddHeader("Authorization", "Bearer " + resultToken.Token);
            
            IRestResponse response = client.Execute(request);
            return View();
        }
    }
}