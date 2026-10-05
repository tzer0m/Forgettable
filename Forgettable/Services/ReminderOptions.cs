namespace Forgettable.Services
{
    /// <summary>
    /// Settings for the daily reminder notification.
    /// </summary>
    public class ReminderOptions
    {
        /// <summary>
        /// The time of day the reminder is sent, e.g. 09:00.
        /// </summary>
        public TimeOnly Time { get; set; }

        /// <summary>
        /// The time zone the reminder time is in, e.g. Europe/London.
        /// </summary>
        public string TimeZone { get; set; } = string.Empty;
    }
}