namespace Forgettable.Models
{
    /// <summary>
    /// What the widget endpoint returns.
    /// </summary>
    public class WidgetResponse
    {
        /// <summary>
        /// The unbooked, unarchived item with the earliest due date, or null if there isn't one.
        /// </summary>
        public WidgetItem? Next { get; set; }
    }
}