using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digest_auth_test
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.Write("usage: url user password");
                Environment.Exit(1);
            }

            var url = args[0];
            var user = args[1];
            var password = args[2];

#if OLDCODE
            if (false)
            {
                var response = Http.CreateRequest(url, user, password);
                var headers = response.Headers;
                var statuscode = (int)response.StatusCode;
                var statusdesc = response.StatusDescription;
                Console.WriteLine(statuscode);
                Console.WriteLine(statusdesc);
                Console.WriteLine(headers.ToString());
            }
            else
#endif
            {
                var response = Http.WebServiceCall(url, user, password);


            }
        }
    }
}
