using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCBBOOK.UCBI.Core.RealPresence.GenaralService
{
    interface IHttpRequest
    {
        string HttpPostRequestWithToken(string url, string dataJson, string token, string contentType, string accpetHeader);
        string HttpPostRequest(string url, string dataJson, string contentType, string accept);
        string HttpGetRequest(string url,string data);
    }
}
