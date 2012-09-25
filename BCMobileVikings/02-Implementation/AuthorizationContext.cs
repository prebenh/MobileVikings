using System.Globalization;
using System.Net;
using Windows.Storage;

namespace MobileVikings.BackEnd.Implementation
{
    /// <summary>
    /// The context to authenticate the user for the request using bacis authentication.
    /// </summary>
    public class AuthenticationContext
    {
        private readonly string _authorizationInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationContext" /> class.
        /// </summary>
        public AuthenticationContext()
        {
            if (ApplicationData.Current.RoamingSettings.Values.ContainsKey("AuthorizationInfo") && ApplicationData.Current.RoamingSettings.Values["AuthorizationInfo"] != null)
            {
                _authorizationInfo = ApplicationData.Current.RoamingSettings.Values["AuthorizationInfo"].ToString();
            }
        }

        /// <summary>
        /// Authorizes the specified request.
        /// Adds the basic authorizaiton info to the headers of the http web request
        /// </summary>
        /// <param name="request">The request.</param>
        public void Authorize(HttpWebRequest request)
        {
            if (request != null)
            {
                request.Headers["Authorization"] = string.Format(CultureInfo.InvariantCulture,"Basic {0}", _authorizationInfo);
            }
        }

    }
}
