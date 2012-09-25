namespace FEMobileVikings.Models
{
    /// <summary>
    /// Shows the usage in a grid view.
    /// </summary>
    public class UsageItem : GroupItem
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is data.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is data; otherwise, <c>false</c>.
        /// </value>
        public bool IsData { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is voice.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is voice; otherwise, <c>false</c>.
        /// </value>
        public bool IsVoice { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is SMS.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is SMS; otherwise, <c>false</c>.
        /// </value>
        public bool IsSms { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is MMS.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is MMS; otherwise, <c>false</c>.
        /// </value>
        public bool IsMms { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public string Duration { get; set; }

        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        /// <value>
        /// The start.
        /// </value>
        public string Start { get; set; }

        /// <summary>
        /// Gets the logo.
        /// </summary>
        /// <value>
        /// The logo.
        /// </value>
        public char Logo
        {
            get
            {
                int displayValue = 0;
                if (IsData)
                {
                    displayValue = 0xE128;
                }
                else if (IsVoice)
                {
                    displayValue = 0xE13A;
                }
                else if (IsSms)
                {
                    displayValue = 0xE134;
                }
                else if (IsMms)
                {
                    displayValue = 0xE156;
                }

                return (char) displayValue;
            }
        }

    }
}