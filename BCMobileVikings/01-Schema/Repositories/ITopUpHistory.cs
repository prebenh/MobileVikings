using System.Collections.Generic;
using System.Threading.Tasks;
using MobileVikings.BackEnd.Schema.DTO;

namespace MobileVikings.BackEnd.Schema.Repositories
{
    /// <summary>
    /// Repository for the top up history.
    /// </summary>
    public interface ITopUpHistory
    {
        /// <summary>
        /// Gets the history of the specified mobile number.
        /// </summary>
        /// <param name="mobileNumber">The mobile number.</param>
        /// <returns></returns>
        Task<IEnumerable<TopUpHistory>> GetHistory(string mobileNumber);
    }
}