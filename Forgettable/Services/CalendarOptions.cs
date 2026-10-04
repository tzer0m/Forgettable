namespace Forgettable.Services
{
    /// <summary>
    /// Settings for the calendar feed.
    /// </summary>
    public class CalendarOptions
    {
        /// <summary>
        /// The secret token that must be in the feed URL.
        /// </summary>
        public string Token { get; set; } = string.Empty;
    }
}