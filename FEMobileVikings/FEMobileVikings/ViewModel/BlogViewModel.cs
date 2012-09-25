using System;
using System.Collections.ObjectModel;
using System.Linq;
using FEMobileVikings.Models;
using FEMobileVikings.Services;
using MobileVikings.BackEnd.Schema.Repositories;
using Windows.ApplicationModel.Resources;

namespace FEMobileVikings.ViewModel
{
    /// <summary>
    /// View model for the blog
    /// </summary>
    public class BlogViewModel : MobileVikingsViewModelBase
    {
        private readonly IRss _rss;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogViewModel" /> class.
        /// </summary>
        /// <param name="rss">The RSS.</param>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="resourceLoader">The resource loader.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public BlogViewModel(IRss rss ,INavigationService navigationService, ResourceLoader resourceLoader) : base(navigationService, resourceLoader)
        {
            if(rss == null)
            {
                throw new  ArgumentNullException("rss");
            }

            _rss = rss;

            BlogPosts = new ObservableCollection<BlogPost>();
            LoadBlogPosts();
        }

        /// <summary>
        /// Gets or sets the blog posts.
        /// </summary>
        /// <value>
        /// The blog posts.
        /// </value>
        public ObservableCollection<BlogPost> BlogPosts { get; set; }

        private async void LoadBlogPosts()
        {
                IsLoading = true;
                var rssItems = await _rss.GetLatestNews();
                if (rssItems != null && rssItems.Any())
                {
                    foreach (var rssItem in rssItems)
                    {
                        BlogPosts.Add(new BlogPost(rssItem));
                    }
                }
                IsLoading = false;
        }
    }
}
