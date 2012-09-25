using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MobileVikings.BackEnd.Schema.DTO;
using MobileVikings.BackEnd.Schema.Repositories;
using Newtonsoft.Json;
using GalaSoft.MvvmLight.Messaging;
using Windows.Storage;

namespace MobileVikings.BackEnd.Implementation.Repositories
{
    /// <summary>
    /// Repository to connect to the Mobile Vikings twitter stream.
    /// </summary>
    public class Tweets : ITweets
    {
        private StorageFolder _folder;
        private IReadOnlyList<StorageFile> _files;

        /// <summary>
        /// Initializes this instance.
        /// Load the images of Mobile Vikings team.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Initialize()
        {
            try
            {
                var assets = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
                _folder = await assets.GetFolderAsync("People");
                _files = await _folder.GetFilesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gets the latest tweets.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Tweet>> GetLatestTweets()
        {
            var request = (HttpWebRequest)WebRequest.Create(new Uri("http://api.twitter.com/1/statuses/user_timeline.json?screen_name=mobilevikings&trim_user=1&include_entities=0&exclude_replies=0"));

            try
            {
                var response = (HttpWebResponse)await request.GetResponseAsync();

                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream);
                    var json = reader.ReadToEnd();

                    var tweets = JsonConvert.DeserializeObject<List<Tweet>>(json);

                    foreach (var tweet in tweets)
                    {
                        SetImage(tweet);
                    }

                    return tweets;
                }
            }
            catch (WebException ex)
            {
                Messenger.Default.Send<WebException>(ex);
                return null;
            }
        }

        private void SetImage(Tweet tweet)
        {
            var index = tweet.Text.LastIndexOf('^');
            if (index > 0)
            {
                var initials = tweet.Text.Substring(index + 1);
                var fileName = string.Format(CultureInfo.InvariantCulture,"{0}.png", initials.ToUpper());

                if (_files.Any(x => x.Name == fileName))
                {
                    tweet.Image = new Uri(string.Format(CultureInfo.InvariantCulture,"ms-appx:///Assets/People/{0}", fileName));
                }
            }
        }
    }
}
