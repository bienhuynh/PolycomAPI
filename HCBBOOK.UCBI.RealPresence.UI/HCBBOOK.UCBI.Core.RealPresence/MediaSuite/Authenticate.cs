using HCBBOOK.UCBI.Core.RealPresence.GenaralService;
using HCBBOOK.UCBI.Core.RealPresence.Models.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCBBOOK.UCBI.Core.RealPresence.MediaSuite
{
    public class Authenticate:IAuthenticate
    {
        /// <summary>
        /// Tick Authenticate login
        /// </summary>
        public bool isLogin;
        private string username;

        /// <summary>
        /// Ip or domain name server include port
        /// </summary>
        private string ipServer;
        private string url;
        public Authenticate(string server, string username, string password)
        {
            this.username = username;
            this.password = password;
            this.ipServer = server;
            this.isLogin = false;
            url = "https://" + ipServer + "/msc/rest/accessToken";
        }
        public string GetUsername()
        {
            return username;
        }

        public void SetUsername(string value)
        {
            username = value;
        }

        private string password;

        public string IpServer { get => ipServer; set => ipServer = value; }
        public string Url { get => url; set => url = value; }
        
        public string GetPassword()
        {
            return password;
        }

        public void SetPassword(string value)
        {
            password = value;
        }

        public JsonResultLogin CheckLogin()
        {
            string token = null;
            MyHttpRequest httpRequest = new MyHttpRequest();
            string json = JsonConvert.SerializeObject(new JsonRequestlogin { userName = this.username, password = this.password });
            string contenType = "application/vnd.plcm.plcm-csc+json";
            string acceptHeader = "application/vnd.plcm.plcm-csc+json";
            token = httpRequest.HttpPostRequest(url, json, contenType, acceptHeader);
            if (token != "-1")
            {
                this.isLogin = !isLogin;
                return JsonConvert.DeserializeObject<JsonResultLogin>(token);
            }
            this.isLogin = false;
            return null;
        }
    }
}
