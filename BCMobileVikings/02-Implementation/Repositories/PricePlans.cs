using System.Threading.Tasks;
using MobileVikings.BackEnd.Schema.DTO;
using MobileVikings.BackEnd.Schema.Repositories;

namespace MobileVikings.BackEnd.Implementation.Repositories
{
    /// <summary>
    /// Repository for the price plans
    /// </summary>
    public class PricePlans : Repository<PricePlan>, IPricePlans
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PricePlans" /> class.
        /// </summary>
        public PricePlans() 
            : base("https://mobilevikings.com/api/2.0/basic/price_plan_details.json")
        {
        }

        /// <summary>
        /// Gets the price plan.
        /// </summary>
        /// <returns></returns>
        public async Task<PricePlan> GetPricePlan()
        {
            return await Get();
        }
    }
}
