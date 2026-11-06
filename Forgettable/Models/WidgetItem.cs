namespace Forgettable.Models
{
    /// <summary>
    /// The next item due, as shown by the Tidgets home screen widget.
    /// </summary>
    public class WidgetItem
    {
        /// <summary>
        /// Who or what the item is for.
        /// </summary>
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// The item type's friendly name.
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// The date the item is due.
        /// </summary>
        public DateOnly DueDate { get; set; }
    }
}