using System.Collections.Generic;
using Newtonsoft.Json;

namespace MobileVikings.BackEnd.Schema.DTO
{
    /// <summary>
    /// The price plan details of the given mobile number.
    /// </summary>
    public class PricePlan
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [JsonProperty(PropertyName = "top_up_amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the prices.
        /// </summary>
        /// <value>
        /// The prices.
        /// </value>
        [JsonProperty(PropertyName = "prices")]
        public IEnumerable<Price> Prices{ get; set; }
        /// <summary>
        /// Gets or sets the bundles.
        /// </summary>
        /// <value>
        /// The bundles.
        /// </value>
        [JsonProperty(PropertyName = "bundles")]
        public IEnumerable<Bundle> Bundles { get; set; }
    }
}
