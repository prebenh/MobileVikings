using System;
using System.Globalization;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MobileVikings.BackEnd.Schema.Services;
using Windows.Storage;

namespace MobileVikings.BackEnd.Implementation.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        public async Task<bool> SignIn(string userName, string password)
        {
            if(string.IsNullOrEmpty(userName)||string.IsNullOrEmpty(password))
            {
                return false;
            }

            var authorizationInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(
                string.Format(CultureInfo.InvariantCulture, "{0}:{1}", userName, password)));

            var request = (HttpWebRequest)WebRequest.Create(
                new Uri("https://mobilevikings.com/api/2.0/basic/msisdn_list.json?alias=1"));

            request.Headers["Authorization"] = string.Format("Basic {0}", authorizationInfo);

            try
            {
                await request.GetResponseAsync();

                ApplicationData.Current.RoamingSettings.Values["AuthorizationInfo"] = authorizationInfo;
                return true;

            }
            catch (WebException exception)
            {
                if (exception.Message.Contains("401"))
                {
                    ApplicationData.Current.RoamingSettings.Values.Remove("AuthorizationInfo");
                }
                else
                {
                    Messenger.Default.Send<WebException>(exception);
                }
                return false;
            }


        }

        public void SignOut()
        {
            ApplicationData.Current.RoamingSettings.Values.Remove("AuthorizationInfo");
        }
    }
}
