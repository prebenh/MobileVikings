using System.Collections.Generic;
using System.Threading.Tasks;
using MobileVikings.BackEnd.Implementation.Services;
using MobileVikings.BackEnd.Schema.DTO;
using MobileVikings.BackEnd.Schema.Repositories;

namespace MobileVikings.BackEnd.Implementation.Repositories
{
    /// <summary>
    /// Repository to connect with the mobile vikings rss feed
    /// </summary>
    public class Rss : IRss
    {
        /// <summary>
        /// Gets the latest news.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RssItem>> GetLatestNews()
        {
            var service = new RssService();

            return await service.GetRssItems();
        }
    }
}
