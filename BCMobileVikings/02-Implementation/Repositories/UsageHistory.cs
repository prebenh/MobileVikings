using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using MobileVikings.BackEnd.Schema.DTO;
using MobileVikings.BackEnd.Schema.Repositories;

namespace MobileVikings.BackEnd.Implementation.Repositories
{
    /// <summary>
    /// Repository to get the usage history.
    /// </summary>
    public class UsageHistory : Repository<Usage>,  IUsageHistory
    {
        private const string Url = "https://mobilevikings.com/api/2.0/basic/usage.json?msisdn={0}";

        /// <summary>
        /// Gets the usage history for the specified mobile number.
        /// </summary>
        /// <param name="mobileNumber">The mobile number.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Usage>> GetUsage(string mobileNumber)
        {
            Uri = new Uri(string.Format(CultureInfo.InvariantCulture, Url, mobileNumber), UriKind.Absolute);

            return await Read();
        }
    }
}
