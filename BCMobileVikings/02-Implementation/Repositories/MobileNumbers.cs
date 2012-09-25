using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using DTO = MobileVikings.BackEnd.Schema.DTO;
using MobileVikings.BackEnd.Schema.Repositories;

namespace MobileVikings.BackEnd.Implementation.Repositories
{
    /// <summary>
    /// The repository for the mobile numbers
    /// </summary>
    public class MobileNumbers : Repository<DTO.MobileNumber>, IMobileNumbers
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MobileNumbers" /> class.
        /// </summary>
        public MobileNumbers()
            : base("https://mobilevikings.com/api/2.0/basic/msisdn_list.json?alias=1")
        {
        }

        /// <summary>
        /// Gets all mobile numbers
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DTO.MobileNumber>> GetAll()
        {
            return await Read();
        }

        /// <summary>
        /// Determines whether the specified mobile number is a mobile viking.
        /// </summary>
        /// <param name="mobileNumber">The mobile number.</param>
        /// <returns></returns>
        /// <exception cref="System.TimeoutException"></exception>
        public async Task<bool> IsMobileViking(string mobileNumber)
        {
            bool returnValue = false;
            try
            {
                var request =
                    (HttpWebRequest)
                    WebRequest.Create(
                        new Uri(
                            string.Format("http://vikingland.mobilevikings.com/checkBridge.php?msisdn={0}", mobileNumber),
                            UriKind.Absolute));
                var response = await request.GetResponseAsync();
                var jsonResult = GetJsonResult(response);
                var checkResponse = JsonConvert.DeserializeObject<DTO.CheckResponse>(jsonResult);
                if (!string.IsNullOrEmpty(checkResponse.ErrorMessage) && checkResponse.ErrorMessage.Contains("Throttling"))
                {
                    throw new TimeoutException("Wait 10 minutes");
                }
                returnValue = checkResponse.Result;
            }
            catch (WebException exception)
            {
                Messenger.Default.Send<WebException>(exception);
            }

            return returnValue;
        }

      
    }
}
