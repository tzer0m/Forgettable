namespace Forgettable.Models
{
    /// <summary>
    /// Base class for every tracked item.
    /// </summary>
    public abstract class Item
    {
        /// <summary>
        /// The primary key.
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// The item's name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The date the item expires.
        /// </summary>
        public DateOnly ExpiryDate { get; set; }

        /// <summary>
        /// Whether the item auto-renews.
        /// </summary>
        public bool AutoRenew { get; set; } = false;
    }
}