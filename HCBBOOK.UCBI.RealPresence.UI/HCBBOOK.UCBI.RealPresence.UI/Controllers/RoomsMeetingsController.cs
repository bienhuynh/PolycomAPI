using HCBBOOK.UCBI.Core.RealPresence.GenaralService;
using HCBBOOK.UCBI.Core.RealPresence.MediaSuite;
using HCBBOOK.UCBI.Core.RealPresence.Models.API;
using HCBBOOK.UCBI.Core.RealPresence.Models.App;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            string url = "https://rm.vnmeeting.com:8443/api/rest/conferences";
            string username = "admin";
            string password = "Polycom!23";
            var client = new RestClient
            {
                BaseUrl = new Uri(url),
                Authenticator = new HttpBasicAuthenticator(username, password)
            };
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "application/vnd.plcm.plcm-conference-list+json");
            //request.AddHeader("Authorization", "Basic YWRtaW46UG9seWNvbSEyMw==");
            IRestResponse response = client.Execute(request);
            RootPlcmConference obj = JsonConvert.DeserializeObject<RootPlcmConference>(response.Content);
            return View(obj);
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
        public ActionResult ControlRoomMeeting(string id)
        {
            string url = "https://rm.vnmeeting.com:8443/api/rest/conferences/6969";
            string username = "admin";
            string password = "Polycom!23";
            var client = new RestClient
            {
                BaseUrl = new Uri(url),
                Authenticator = new HttpBasicAuthenticator(username, password)
            };
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cache-Control", "no-cache");
            //request.AddHeader("Accept", "application/vnd.plcm.plcm-conference+json");
            request.AddHeader("Accept", "application/vnd.plcm.plcm-participant-list+json");
            IRestResponse response = client.Execute(request);
            var obj = JsonConvert.DeserializeObject<object>(response.Content);
            return View();
        }
    }
}