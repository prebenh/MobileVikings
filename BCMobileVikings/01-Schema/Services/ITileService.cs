using System.Collections.Generic;
using MobileVikings.BackEnd.Schema.DTO;

namespace MobileVikings.BackEnd.Schema.Services
{
    /// <summary>
    /// Service to update the Application tile.
    /// </summary>
    public interface ITileService
    {
        /// <summary>
        /// Updates the live tiles with the simbalace.
        /// </summary>
        /// <param name="simBalance">The sim balance.</param>
        void UpdateLiveTile(Dictionary<string,SimBalance> simBalance);
    }
}