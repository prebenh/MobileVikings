using System;
using System.Globalization;
using System.Threading.Tasks;
using MobileVikings.BackEnd.Schema.Repositories;
using DTO = MobileVikings.BackEnd.Schema.DTO;

namespace MobileVikings.BackEnd.Implementation.Repositories
{
    /// <summary>
    /// Repository to get the sim balance.
    /// </summary>
    public class SimBalance : Repository<DTO.SimBalance>, ISimBalance
    {
        private const string Url = "https://mobilevikings.com/api/2.0/basic/sim_balance.json?msisdn={0}";

        /// <summary>
        /// Gets the sim balance for the specified mobile number.
        /// </summary>
        /// <param name="mobileNumber">The mobile number.</param>
        /// <returns></returns>
        public async Task<DTO.SimBalance> GetBalance(string mobileNumber)
        {
            Uri = new Uri(string.Format(CultureInfo.InvariantCulture, Url, mobileNumber), UriKind.Absolute);

            return await Get();
        }
    }
}
