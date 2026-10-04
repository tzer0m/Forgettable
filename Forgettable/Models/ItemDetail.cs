namespace Forgettable.Models
{
    /// <summary>
    /// A single labelled value shown in an item's details.
    /// </summary>
    public class ItemDetail
    {
        /// <summary>
        /// The label, e.g. "Expiry Date".
        /// </summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// The value formatted as text.
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// The raw value, for displays that format it themselves.
        /// </summary>
        public object? Value { get; set; }

        /// <summary>
        /// An optional explanation shown alongside the value.
        /// </summary>
        public string? Hint { get; set; }
    }
}