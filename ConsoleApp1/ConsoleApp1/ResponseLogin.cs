using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ResponseLogin
    {
        [JsonProperty("expiresIn")]
        public int ExpiresIn { get; set; }
        [JsonProperty("refreshToken")]
        public object RefreshToken { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("tokenType")]
        public object TokenType { get; set; }
    }
}
