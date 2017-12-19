using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Mono.Web;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Newtonsoft.Json;
using System.Security.Cryptography;
using RestSharp;
using RestSharp.Authenticators;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string server = "record.ucbi-global.com:443";
            //string server = "221.132.28.43:8443";
            string URL = "https://" + server + "/msc/rest/accessToken";
            /// Bat dau chung thuc
            ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate,
                     X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
            ///Ket thuc chung thuc
            Dictionary<string, string> d = new Dictionary<string, string>();//Tham so 
            d.Add("userName", "admin");
            d.Add("password", "Polycom!23");
            string result = HttpPostRequest(URL, d);
            Console.WriteLine(result);

            string URL1 = "https://admin:Polycom!23@rm.vnmeeting.com:8443/api/rest/remote-alert-profiles";
            string contentType = "application/vnd.plcm.plcm-remote-alert-profile-list+json";
            //Console.WriteLine(HttpPostRequest(URL1, "", contentType,contentType));
            Test_API_Access(URL1);

            /*-----------------------------*/
            string url = "https://rm.vnmeeting.com:8443/api/rest/conferences";
            string username = "LOCAL\admin";
            string password = "Polycom!23";
            var client = new RestClient
            {
                BaseUrl = new Uri(url),
                Authenticator = new HttpBasicAuthenticator(username, password)
            };
            //var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            //request.AddHeader("Cache-Control", "no-cache");
            //request.AddHeader("Authorization", "Bearer " + resultToken.Token);

            IRestResponse response = client.Execute(request);
            Console.Write(response.ResponseStatus);
            /*---------------------------------*/

            string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{username}:{password}"));
            var client1 = new RestClient(url);
            var request1 = new RestRequest(Method.GET);
            request1.AddHeader("Accept", "application/vnd.plcm.plcm-conference-list+json");
            request.AddHeader("Authorization", $"Basic {encoded}");
            IRestResponse response1 = client.Execute(request1);
            
            Console.Write(response1.Content);

            Console.ReadLine();
        }
        private static string HttpPostRequest(string url, Dictionary<string, string> postParameters)
        {
            
            string postData = "";
            var json = JsonConvert.SerializeObject(new LoginModel { userName = "admin", password = "Polycom!23"});
            //var json = "start-before: '" + DateTime.Now + "', start-after: '"+DateTime.Now+1+ "', conference-room-identifier: '21345324'";
            //foreach (string key in postParameters.Keys)
            //{
            //    postData += HttpUtility.UrlEncode(key) + "="
            //          + HttpUtility.UrlEncode(postParameters[key]) + "&";
            //}
            postData = json;
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            myHttpWebRequest.Method = "POST";

            byte[] data = Encoding.ASCII.GetBytes(postData);

            //myHttpWebRequest.ContentType = "application/vnd.plcm.plcm-csc+json";
            myHttpWebRequest.ContentType = "application/vnd.plcm.plcm-csc+json";
            
            myHttpWebRequest.Accept = "application/vnd.plcm.plcm-csc+json";
            myHttpWebRequest.ContentLength = data.Length;

            Stream requestStream = myHttpWebRequest.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            Stream responseStream = myHttpWebResponse.GetResponseStream();

            StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

            string pageContent = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            responseStream.Close();

            myHttpWebResponse.Close();

            return pageContent;
        }

        private static string HttpPostRequest(string url, string dataJson, string contentType, string accept)
        {
            try
            {

                string postData = dataJson;

                HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                myHttpWebRequest.Method = "POST";

                byte[] data = Encoding.ASCII.GetBytes(postData);

                myHttpWebRequest.ContentType = contentType;
                myHttpWebRequest.UseDefaultCredentials = true;
                myHttpWebRequest.PreAuthenticate = true;
                myHttpWebRequest.Accept = accept;
                myHttpWebRequest.ContentLength = data.Length;

                Stream requestStream = myHttpWebRequest.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                Stream responseStream = myHttpWebResponse.GetResponseStream();

                StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

                string pageContent = myStreamReader.ReadToEnd();

                myStreamReader.Close();
                responseStream.Close();

                myHttpWebResponse.Close();

                return pageContent;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return "not get data";
        }

        private static void Test_API_Access(string url)
        {
            string MoodysWebstring = url;
            Uri MoodysWebAddress = new Uri(MoodysWebstring);
            HttpWebRequest request = WebRequest.Create(MoodysWebAddress) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/vnd.plcm.plcm-conference-list-subscription+json";
            //request.ContentType = "text/plain";
            string results = string.Empty;
            HttpWebResponse response;
            try
            {
                using (response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    results = reader.ReadToEnd();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine(results);
        }
        public static string HmacSha1SignRequest(string privateKey, string valueToHash)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(privateKey);
            HMACSHA1 hmacsha1 = new HMACSHA1(keyByte);
            byte[] messageBytes = encoding.GetBytes(valueToHash);
            byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
            var hashedValue = Convert.ToBase64String(hashmessage);
            return hashedValue;
        }
    }
}
public class LoginModel
{
    public string userName { get; set; }
    public string password { get; set; }
}