using System;
using Newtonsoft.Json;

namespace MobileVikings.BackEnd.Schema.DTO
{
    /// <summary>
    /// The history of the top ups of a simcard
    /// </summary>
    public class TopUpHistory
    {
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }
        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>
        /// The method.
        /// </value>
        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }
        /// <summary>
        /// Gets or sets the received.
        /// </summary>
        /// <value>
        /// The received.
        /// </value>
        [JsonProperty(PropertyName = "executed_on")]
        public DateTime Received { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
