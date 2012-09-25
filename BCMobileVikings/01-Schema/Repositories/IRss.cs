using System.Collections.Generic;
using System.Threading.Tasks;
using MobileVikings.BackEnd.Schema.DTO;

namespace MobileVikings.BackEnd.Schema.Repositories
{
    /// <summary>
    /// Repository to connect with the mobile vikings rss feed
    /// </summary>
    public interface IRss
    {
        /// <summary>
        /// Gets the latest news.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RssItem>> GetLatestNews();
    }
}
