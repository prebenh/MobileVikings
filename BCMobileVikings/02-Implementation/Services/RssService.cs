using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MobileVikings.BackEnd.Schema.DTO;
using Windows.Web.Syndication;

namespace MobileVikings.BackEnd.Implementation.Services
{
    public class RssService
    {
        private const string Rssurl = "http://feeds.feedburner.com/MobileVikingsBlog";

        public async Task<IEnumerable<RssItem>> GetRssItems()
        {
            var syndicationClient = new SyndicationClient();
            var syndicationFeed = await syndicationClient.RetrieveFeedAsync(new Uri(Rssurl));

            return syndicationFeed.Items.Select(syndicationItem => new RssItem
                                                                       {
                                                                           Date = syndicationItem.PublishedDate.UtcDateTime,
                                                                           Description = Regex.Replace(syndicationItem.Summary.Text, "<.*?>", string.Empty),
                                                                           Title = syndicationItem.Title.Text,
                                                                           ImageLink = FindImageUrl(syndicationItem.Summary.Text),
                                                                           Link = syndicationItem.Id
                                                                       });

        }

        private static string FindImageUrl(string description)
        {
            if (description.Contains("<img"))
            {
                var startIndex = description.IndexOf("src=\"", StringComparison.Ordinal) + 5;
                var url = description.Substring(startIndex);
                return url.Remove(url.IndexOf('"'));
            }

            return null;
        }
    }
}