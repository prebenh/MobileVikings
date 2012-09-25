using System.Threading.Tasks;
using MobileVikings.BackEnd.Schema.DTO;

namespace MobileVikings.BackEnd.Schema.Repositories
{
    /// <summary>
    /// Repository to get the sim balance.
    /// </summary>
    public interface ISimBalance
    {
        /// <summary>
        /// Gets the sim balance for the specified mobile number.
        /// </summary>
        /// <param name="mobileNumber">The mobile number.</param>
        /// <returns></returns>
        Task<SimBalance> GetBalance(string mobileNumber);
    }
}