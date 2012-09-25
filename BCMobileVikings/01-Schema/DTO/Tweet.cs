using System;
using Newtonsoft.Json;

namespace MobileVikings.BackEnd.Schema.DTO
{
    /// <summary>
    /// A tweet from twitter.com
    /// </summary>
    public class Tweet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tweet" /> class.
        /// </summary>
        public Tweet()
        {
            Image = new Uri("ms-appx:///Assets/NoImage.png");
        }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        [JsonProperty(PropertyName = "created_at")]
        [JsonConverter(typeof(TwitterDateTimeConverter))]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public Uri Image { get; set; }
    }
}
