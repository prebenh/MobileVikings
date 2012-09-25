using Newtonsoft.Json;

namespace MobileVikings.BackEnd.Schema.DTO
{
    /// <summary>
    /// The response for who is a mobile viking
    /// </summary>
    public class CheckResponse
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CheckResponse" /> is result.
        /// </summary>
        /// <value>
        ///   <c>true</c> if result; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty(PropertyName = "result")]
        public bool Result { get; set; }
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        [JsonProperty(PropertyName = "error_message")]
        public string ErrorMessage { get; set; }
    }
}
