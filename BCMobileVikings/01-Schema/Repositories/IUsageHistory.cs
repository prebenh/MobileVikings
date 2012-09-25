using System.Collections.Generic;
using System.Threading.Tasks;
using MobileVikings.BackEnd.Schema.DTO;

namespace MobileVikings.BackEnd.Schema.Repositories
{
    /// <summary>
    /// Repository to get the usage history.
    /// </summary>
    public interface IUsageHistory
    {
        /// <summary>
        /// Gets the usage history for the specified mobile number.
        /// </summary>
        /// <param name="mobileNumber">The mobile number.</param>
        /// <returns></returns>
        Task<IEnumerable<Usage>> GetUsage(string mobileNumber);
    }
}