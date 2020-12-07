using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Models
{
    public class ApiServiceInfo
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scopes { get; set; }

        public ApiServiceInfo(string clientId, string clientSecret, string scopes)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Scopes = scopes;
        }
    }
}
