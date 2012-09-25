using System.Collections.Generic;
using System.Threading.Tasks;
using MobileVikings.BackEnd.Schema.DTO;

namespace MobileVikings.BackEnd.Schema.Repositories
{
    /// <summary>
    /// Repository to connect to the Mobile Vikings twitter stream.
    /// </summary>
    public interface ITweets
    {
        /// <summary>
        /// Initializes this instance.
        /// Load the images of Mobile Vikings team.
        /// </summary>
        /// <returns></returns>
        Task<bool> Initialize();
        /// <summary>
        /// Gets the latest tweets.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Tweet>> GetLatestTweets();
    }
}
