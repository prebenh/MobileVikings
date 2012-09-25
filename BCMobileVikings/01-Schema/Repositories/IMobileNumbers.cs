using System.Collections.Generic;
using System.Threading.Tasks;
using MobileVikings.BackEnd.Schema.DTO;
namespace MobileVikings.BackEnd.Schema.Repositories
{
    /// <summary>
    /// The repository for the mobile numbers
    /// </summary>
    public interface IMobileNumbers
    {
        /// <summary>
        /// Gets all mobile numbers
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MobileNumber>> GetAll();

        /// <summary>
        /// Determines whether the specified mobile number is a mobile viking.
        /// </summary>
        /// <param name="mobileNumber">The mobile number.</param>
        /// <returns></returns>
        Task<bool> IsMobileViking(string mobileNumber);
    }
}