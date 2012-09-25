using System;
using System.Net;
using MobileVikings.BackEnd.Schema.DTO;

namespace FEMobileVikings.Models
{
    /// <summary>
    /// Model of a blog post
    /// </summary>
    public class BlogPost
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPost" /> class.
        /// </summary>
        public BlogPost()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPost" /> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public BlogPost(RssItem item)
        {
            Title = item.Title;
            Description = WebUtility.HtmlDecode(item.Description);
            Date = item.Date;
            Url = new Uri(item.Link, UriKind.Absolute);

            if(!string.IsNullOrEmpty(item.ImageLink))
            {
                ImageUrl = new Uri(item.ImageLink, UriKind.Absolute);
            }
            else
            {
                ImageUrl = new Uri("ms-appx:///Assets/NoImage.png");
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        public Uri ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public Uri Url { get; set; }
    }
}
