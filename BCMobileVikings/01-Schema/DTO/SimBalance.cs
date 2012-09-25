using System;
using Newtonsoft.Json;

namespace MobileVikings.BackEnd.Schema.DTO
{

    /// <summary>
    /// The balance of a specified sim card
    /// </summary>
    public class SimBalance
    {
        /// <summary>
        /// Gets or sets the credit.
        /// </summary>
        /// <value>
        /// The credit.
        /// </value>
        [JsonProperty(PropertyName = "credits")]
        public decimal Credit { get; set; }
        [JsonProperty(PropertyName = "valid_until")]
        public DateTime ValidUntil { get; set; }
        /// <summary>
        /// Gets or sets the SMS count.
        /// </summary>
        /// <value>
        /// The SMS count.
        /// </value>
        [JsonProperty(PropertyName = "sms")]
        public int SmsCount { get; set; }
        /// <summary>
        /// Gets or sets the mobile vikings SMS count.
        /// </summary>
        /// <value>
        /// The mobile vikings SMS count.
        /// </value>
        [JsonProperty(PropertyName = "sms_super_on_net")]
        public int MobileVikingsSmsCount { get; set; }
        /// <summary>
        /// Gets or sets the mobile vikings credit.
        /// </summary>
        /// <value>
        /// The mobile vikings credit.
        /// </value>
        [JsonProperty(PropertyName = "voice_super_on_net")]
        public decimal MobileVikingsCredit { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is expired.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is expired; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty(PropertyName = "is_expired")]
        public bool IsExpired { get; set; }

        private decimal _data;
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [JsonProperty(PropertyName = "data")]
        public decimal Data
        {
            get { return decimal.Divide(_data, 1048576); }
            set { _data = value; }
        }

    }
}
