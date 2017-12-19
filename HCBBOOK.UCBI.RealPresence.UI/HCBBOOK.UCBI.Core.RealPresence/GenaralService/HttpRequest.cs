using HCBBOOK.UCBI.Core.RealPresence.Models.App;
using HCBBOOK.UCBI.Core.RealPresence.Models.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HCBBOOK.UCBI.Core.RealPresence.GenaralService
{
    public class MyHttpRequest : IHttpRequest
    {
        public string HttpPostRequestWithToken(string url, string dataJson, string token, string contentType, string accpetHeader)
        {
            string pageContent = null;
            try
            {
                string postData = dataJson != null ? dataJson : "";
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                myHttpWebRequest.Method = "GET";

                byte[] data = Encoding.ASCII.GetBytes(postData);

                myHttpWebRequest.ContentType = contentType;
                // authentication
                var cache = new CredentialCache();
                cache.Add(new Uri(url), "Basic", new NetworkCredential("admin", "Polycom!23"));
                myHttpWebRequest.Credentials = cache;
                //myHttpWebRequest.Headers.Add("Authorization", "Bearer " + token);
                myHttpWebRequest.Accept = accpetHeader;
                myHttpWebRequest.ContentLength = data.Length;

                Stream requestStream = myHttpWebRequest.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                Stream responseStream = myHttpWebResponse.GetResponseStream();

                StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

                pageContent = myStreamReader.ReadToEnd();

                myStreamReader.Close();
                responseStream.Close();

                myHttpWebResponse.Close();
            }
            catch(Exception ex)
            {
                //log
                pageContent = "-1";
            }

            return pageContent;
        }

        public string HttpPostRequest(string url, string dataJson, string contentType, string accept)
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
            catch (Exception ex)
            {
                //log
            }
            return "-1";
        }

        public string HttpGetRequest(string url, string data)
        {
            throw new NotImplementedException();
        }
    }
}
