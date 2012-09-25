namespace FEMobileVikings.Models
{
    /// <summary>
    /// Shows the top up history in a grid view.
    /// </summary>
    public class TopUpHistoryItem : GroupItem
    {
        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>
        /// The method.
        /// </value>
        public string Method { get; set; }
        /// <summary>
        /// Gets or sets the received.
        /// </summary>
        /// <value>
        /// The received.
        /// </value>
        public string Received { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { get; set; }
    }
}