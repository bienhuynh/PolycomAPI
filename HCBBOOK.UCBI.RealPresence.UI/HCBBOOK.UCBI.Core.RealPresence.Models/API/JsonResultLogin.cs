using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCBBOOK.UCBI.Core.RealPresence.Models.API
{
    public class JsonResultLogin
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
