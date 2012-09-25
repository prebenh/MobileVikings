using System;

namespace MobileVikings.BackEnd.Schema.DTO
{
    /// <summary>
    /// An RSS feed item
    /// </summary>
    public class RssItem
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }

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
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the image link.
        /// </summary>
        /// <value>
        /// The image link.
        /// </value>
        public string ImageLink { get; set; }
    }
}
