using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using MobileVikings.BackEnd.Schema.DTO;
using Windows.Data.Xml.Dom;
using GalaSoft.MvvmLight.Messaging;

namespace MobileVikings.BackEnd.Implementation.Services
{
    /// <summary>
    /// Service to retrieve an rss feed
    /// </summary>
    public class RssService : IDisposable
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RssService" /> class.
        /// </summary>
        public RssService()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RssService" /> class.
        /// </summary>
        /// <param name="feedUrl">The feed URL.</param>
        public RssService(string feedUrl)
        {
            _feedUrl = feedUrl;
        }

        #endregion

        #region Properties

        private string _feedUrl;
        /// <summary>
        /// Gets or sets the URL of the RSS feed to parse.
        /// </summary>
        public string FeedUrl
        {
            get { return _feedUrl; }
            set { _feedUrl = value; }
        }

        private readonly Collection<RssItem> _items = new Collection<RssItem>();
        /// <summary>
        /// Gets all the items in the RSS feed.
        /// </summary>
        public Collection<RssItem> Items
        {
            get { return _items; }
        }

        private string _title;
        /// <summary>
        /// Gets the title of the RSS feed.
        /// </summary>
        public string Title
        {
            get { return _title; }
        }

        private string _description;
        /// <summary>
        /// Gets the description of the RSS feed.
        /// </summary>
        public string Description
        {
            get { return _description; }
        }

        private DateTime _lastUpdated;
        /// <summary>
        /// Gets the date and time of the retrievel and
        /// parsing of the remote RSS feed.
        /// </summary>
        public DateTime LastUpdated
        {
            get { return _lastUpdated; }
        }

        private TimeSpan _updateFrequency;
        /// <summary>
        /// Gets the time before the feed get's silently updated.
        /// Is TimeSpan.Zero unless the CreateAndCache method has been used.
        /// </summary>
        public TimeSpan UpdateFrequency
        {
            get { return _updateFrequency; }
        }

        #endregion

        #region Methods


        /// <summary>
        /// Retrieves the remote RSS feed and parses it.
        /// </summary>
        /// <exception cref="System.Net.WebException" />
        public async Task<IEnumerable<RssItem>> Execute()
        {
            if (String.IsNullOrEmpty(FeedUrl))
                throw new ArgumentException("The feed url must be set");

            try
            {
                using (var reader = XmlReader.Create(FeedUrl))
                {
                    var doc = await XmlDocument.LoadFromUriAsync(new Uri(FeedUrl, UriKind.Absolute));

                    _title = ParseElement(doc.SelectSingleNode("//channel"), "title");
                    _description = ParseElement(doc.SelectSingleNode("//channel"), "description");
                    ParseItems(doc);

                    _lastUpdated = DateTime.Now;
                }
            }
            catch (WebException exception)
            {
                Messenger.Default.Send<WebException>(exception);
            }
            return _items;
           
        }

        /// <summary>
        /// Parses the xml document in order to retrieve the RSS items.
        /// </summary>
        private void ParseItems(XmlDocument doc)
        {
            _items.Clear();
            XmlNodeList nodes = doc.SelectNodes("rss/channel/item");

            foreach (IXmlNode node in nodes)
            {
                var item = new RssItem
                               {
                                   Title = ParseElement(node, "title"),
                                   Description = TrimDescription(ParseElement(node, "description")),
                                   Link = ParseElement(node, "link"),
                                   ImageLink = FindImageUrl(node)
                               };


                string date = ParseElement(node, "pubDate");
                DateTime dateTime;
                if (DateTime.TryParse(date, out dateTime))
                {
                    item.Date = dateTime;
                }

                _items.Add(item);
            }
        }


        /// <summary>
        /// Removes the read more link from the description.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        private static string TrimDescription(string description)
        {
            var index = description.IndexOf("<a", StringComparison.Ordinal);
            if (index > 0)
            {
                description = description.Remove(index);
            }

            return description;
        }

        /// <summary>
        /// Parses the XmlNode with the specified XPath query 
        /// and assigns the value to the property parameter.
        /// </summary>
        private static string ParseElement(IXmlNode parent, string xPath)
        {
            var node = parent.SelectSingleNode(xPath);
            if (node != null)
                return node.InnerText;
            return null;
        }

        private static string FindImageUrl(IXmlNode parent)
        {
            var nodes = parent.ChildNodes;

            foreach (var node in nodes)
            {
                if (node.NodeName == "content:encoded")
                {
                    if (node.InnerText.Contains("<img"))
                    {
                        var startIndex = node.InnerText.IndexOf("src=\"", StringComparison.Ordinal)+5;
                        var url = node.InnerText.Substring(startIndex);
                        return url.Remove(url.IndexOf('"'));
                    }
                }
            }

            return null;
        }

        #endregion

        #region IDisposable Members

        private bool _isDisposed;

        /// <summary>
        /// Performs the disposal.
        /// </summary>
        private void Dispose(bool disposing)
        {
            if (disposing && !_isDisposed)
            {
                _items.Clear();
                _feedUrl = null;
                _title = null;
                _description = null;
            }

            _isDisposed = true;
        }

        /// <summary>
        /// Releases the object to the garbage collector
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
