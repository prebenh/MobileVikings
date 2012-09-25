using System;
using Newtonsoft.Json;

namespace MobileVikings.BackEnd.Schema.DTO
{
    /// <summary>
    /// A history item
    /// </summary>
    public class Usage
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is data.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is data; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty(PropertyName = "is_data")]
        public bool IsData { get; set; }
        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        /// <value>
        /// The start.
        /// </value>
        [JsonProperty(PropertyName = "start_timestamp")]
        public DateTime Start { get; set; }
        /// <summary>
        /// Gets or sets the end.
        /// </summary>
        /// <value>
        /// The end.
        /// </value>
        [JsonProperty(PropertyName = "end_timestamp")]
        public DateTime End { get; set; }
        /// <summary>
        /// Gets or sets to.
        /// </summary>
        /// <value>
        /// To.
        /// </value>
        [JsonProperty(PropertyName = "to")]
        public string To { get; set; }
        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        [JsonProperty(PropertyName = "balance")]
        public decimal Balance { get; set; }
        /// <summary>
        /// Gets or sets the duration in seconds.
        /// </summary>
        /// <value>
        /// The duration in seconds.
        /// </value>
        [JsonProperty(PropertyName = "duration_connection")]
        public int DurationInSeconds { get; set; }
        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        [JsonProperty(PropertyName = "duration_human")]
        public string Duration { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is incoming.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is incoming; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty(PropertyName = "is_incoming")]
        public bool IsIncoming { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is voice.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is voice; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty(PropertyName = "is_voice")]
        public bool IsVoice { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is MMS.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is MMS; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty(PropertyName = "is_mms")]
        public bool IsMms { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is SMS.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is SMS; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty(PropertyName = "is_sms")]
        public bool IsSms { get; set; }

    }
}
