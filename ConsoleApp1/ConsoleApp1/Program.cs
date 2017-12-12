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
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string server = "record.ucbi-global.com";
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
    }
}
public class LoginModel
{
    public string userName { get; set; }
    public string password { get; set; }
}