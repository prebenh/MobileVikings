using Newtonsoft.Json;

namespace MobileVikings.BackEnd.Schema.DTO
{
    /// <summary>
    ///A user can have different mobile numbers
    /// </summary>
    public class MobileNumber
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty(PropertyName = "alias")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        [JsonProperty(PropertyName = "msisdn")]
        public string Number { get; set; }
    }
}
