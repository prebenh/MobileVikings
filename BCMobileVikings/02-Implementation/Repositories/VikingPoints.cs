using System.Threading.Tasks;
using MobileVikings.BackEnd.Schema.DTO;
using MobileVikings.BackEnd.Schema.Repositories;

namespace MobileVikings.BackEnd.Implementation.Repositories
{
    /// <summary>
    /// Repository for the viking points
    /// </summary>
    public class VikingPoints : Repository<VikingPoint> , IVikingPoints
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VikingPoints" /> class.
        /// </summary>
        public VikingPoints()
            : base("https://mobilevikings.com/api/2.0/basic/points/stats.json")
        {
        }

        /// <summary>
        /// Gets the viking points.
        /// </summary>
        /// <returns></returns>
        public async Task<VikingPoint> GetVikingPoints()
        {
            return await Get();
        }
    }
}
