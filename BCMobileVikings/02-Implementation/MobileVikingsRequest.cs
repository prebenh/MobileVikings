using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MobileVikings.BackEnd.Implementation
{
    public static class MobileVikingsRequest
    {
        public static HttpWebRequest Create(Uri uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);

            var authorizationContext = new AuthenticationContext();

            authorizationContext.Authorize(request);

            return request;
        }
    }
}
