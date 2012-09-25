using System.Collections.ObjectModel;

namespace FEMobileVikings.Models
{
    /// <summary>
    /// Model of a group, to display in a grid view.
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Group" /> class.
        /// </summary>
        public Group()
        {
            Items = new ObservableCollection<GroupItem>();
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public ObservableCollection<GroupItem> Items { get; set; }
    }
}
