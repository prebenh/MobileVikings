using Newtonsoft.Json;

namespace MobileVikings.BackEnd.Schema.DTO
{
    /// <summary>
    /// How much a transaction (call, sms, web, ...) costs
    /// </summary>
    public class Price
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
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets the type id.
        /// </summary>
        /// <value>
        /// The type id.
        /// </value>
        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
    }
}
