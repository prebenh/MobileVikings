using Newtonsoft.Json;

namespace MobileVikings.BackEnd.Schema.DTO
{
    /// <summary>
    ///  A bundle object
    /// </summary>
    public class Bundle
    {
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [JsonProperty(PropertyName = "amount")]
        public int Amount { get; set; }
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
        [JsonProperty(PropertyName = "typeId")]
        public int TypeId { get; set; }
    }
}
