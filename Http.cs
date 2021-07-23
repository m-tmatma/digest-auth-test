using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Security;
using System.IO;

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

        public static string WebServiceCall(string url, string user, string password)
        {
#if !DEBUG
            try
#endif
            {
                string response = string.Empty;

                Uri uri = new Uri(url);

                DigestHttpWebRequest req = new DigestHttpWebRequest(user, password);

                using (HttpWebResponse webResponse = req.GetResponse(uri))
                using (Stream responseStream = webResponse.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader streamReader = new StreamReader(responseStream))
                        {
                            response = streamReader.ReadToEnd();
                        }
                    }
                }
                return response;
            }
#if !DEBUG
            catch (WebException caught)
            {
                throw new WebException(string.Format("Exception in WebServiceCall: {0}", caught.Message));
            }
            catch (Exception caught)
            {
                throw new Exception(string.Format("Exception in WebServiceCall: {0}", caught.Message));
            }
#endif
        }
    }
}
