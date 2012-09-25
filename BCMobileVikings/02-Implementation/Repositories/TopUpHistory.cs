using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using MobileVikings.BackEnd.Schema.Repositories;
using DTO = MobileVikings.BackEnd.Schema.DTO;

namespace MobileVikings.BackEnd.Implementation.Repositories
{
    /// <summary>
    /// Repository for the top up history.
    /// </summary>
    public class TopUpHistory : Repository<DTO.TopUpHistory>, ITopUpHistory
    {
        private const string Url = "https://mobilevikings.com/api/2.0/basic/top_up_history.json?msisdn={0}";

        /// <summary>
        /// Gets the history of the specified mobile number.
        /// </summary>
        /// <param name="mobileNumber">The mobile number.</param>
        /// <returns></returns>
        public async Task<IEnumerable<DTO.TopUpHistory>> GetHistory(string mobileNumber)
        {
            Uri = new Uri(string.Format(CultureInfo.InvariantCulture, Url, mobileNumber), UriKind.Absolute);

            return await Read();
        }
    }
}
