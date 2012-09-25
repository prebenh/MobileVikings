using System;
using System.Collections.ObjectModel;
using System.Linq;
using FEMobileVikings.Services;
using MobileVikings.BackEnd.Schema.DTO;
using MobileVikings.BackEnd.Schema.Repositories;
using Windows.ApplicationModel.Resources;

namespace FEMobileVikings.ViewModel
{
    /// <summary>
    /// View model for the twitter view
    /// </summary>
    public class TwitterViewModel : MobileVikingsViewModelBase
    {
        private readonly ITweets _tweets;

        /// <summary>
        /// Initializes a new instance of the <see cref="TwitterViewModel" /> class.
        /// </summary>
        /// <param name="tweets">The tweets.</param>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="resourceLoader">The resource loader.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public TwitterViewModel(ITweets tweets, INavigationService navigationService, ResourceLoader resourceLoader)
            : base(navigationService, resourceLoader)
        {
            if (tweets == null)
            {
                throw new ArgumentNullException("tweets");
            }
            _tweets = tweets;

            Tweets = new ObservableCollection<Tweet>();
            LoadTweets();

        }

        /// <summary>
        /// Gets or sets the tweets.
        /// </summary>
        /// <value>
        /// The tweets.
        /// </value>
        public ObservableCollection<Tweet> Tweets { get; set; }

        private async void LoadTweets()
        {
            IsLoading = true;
            if (await _tweets.Initialize())
            {
                var tweets = await _tweets.GetLatestTweets();
                if (tweets != null && tweets.Any())
                {
                    foreach (var tweet in tweets)
                    {
                        Tweets.Add(tweet);
                    }
                }
            }
            IsLoading = false;
        }
    }
}
