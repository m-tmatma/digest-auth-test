using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Security;

namespace digest_auth_test
{
    class Http
    {
        public static HttpWebResponse CreateRequest(string url, string user, string password)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";

            var credentialCache = new CredentialCache();
            credentialCache.Add( new Uri(url), "Digest", new NetworkCredential(user, password));
            request.Credentials = credentialCache;

            return request.GetResponse() as HttpWebResponse;
        }
    }
}
