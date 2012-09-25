using System.Threading.Tasks;
using MobileVikings.BackEnd.Schema.DTO;

namespace MobileVikings.BackEnd.Schema.Repositories
{
    /// <summary>
    /// Repository for the viking points
    /// </summary>
    public interface IVikingPoints
    {
        /// <summary>
        /// Gets the viking points.
        /// </summary>
        /// <returns></returns>
        Task<VikingPoint> GetVikingPoints();
    }
}