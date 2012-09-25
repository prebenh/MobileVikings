using Newtonsoft.Json;

namespace MobileVikings.BackEnd.Schema.DTO
{
    /// <summary>
    /// Information about vikin points
    /// </summary>
    public class VikingPoint
    {
        /// <summary>
        /// Gets or sets the used points.
        /// </summary>
        /// <value>
        /// The used points.
        /// </value>
        [JsonProperty(PropertyName = "used_points")]
        public int UsedPoints { get; set; }
        /// <summary>
        /// Gets or sets the available points.
        /// </summary>
        /// <value>
        /// The available points.
        /// </value>
        [JsonProperty(PropertyName = "unused_points")]
        public int AvailablePoints { get; set; }
        /// <summary>
        /// Gets or sets the waiting points.
        /// </summary>
        /// <value>
        /// The waiting points.
        /// </value>
        [JsonProperty(PropertyName = "waiting_points")]
        public int WaitingPoints { get; set; }
        /// <summary>
        /// Gets or sets the top ups used.
        /// </summary>
        /// <value>
        /// The top ups used.
        /// </value>
        [JsonProperty(PropertyName = "topups_used")]
        public int TopUpsUsed { get; set; }
        /// <summary>
        /// Gets or sets the earned points.
        /// </summary>
        /// <value>
        /// The earned points.
        /// </value>
        [JsonProperty(PropertyName = "earned_points")]
        public int EarnedPoints { get; set; }
    }
}
