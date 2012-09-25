using System.Threading.Tasks;
using MobileVikings.BackEnd.Schema.DTO;

namespace MobileVikings.BackEnd.Schema.Repositories
{
    /// <summary>
    /// Repository for the price plans
    /// </summary>
    public interface IPricePlans
    {
        /// <summary>
        /// Gets the price plan.
        /// </summary>
        /// <returns></returns>
        Task<PricePlan> GetPricePlan();
    }
}