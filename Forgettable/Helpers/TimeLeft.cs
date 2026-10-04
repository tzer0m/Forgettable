namespace Forgettable.Helpers
{
    /// <summary>
    /// Describes how long is left until a date in the most readable unit.
    /// </summary>
    public static class TimeLeft
    {
        /// <summary>
        /// Returns the time left until a date, e.g. "5 days", "3.5 weeks" or "1.2 years overdue".
        /// </summary>
        /// <param name="date">The date to count down to.</param>
        public static string Describe(DateOnly date)
        {
            int days = date.DayNumber - DateOnly.FromDateTime(DateTime.Today).DayNumber;
            if (days == 0)
            {
                return "Today";
            }
            string amount = Format(Math.Abs(days));
            return days < 0 ? $"{amount} overdue" : amount;
        }

        /// <summary>
        /// Formats a number of days as days, weeks, months or years.
        /// </summary>
        /// <param name="days">The number of days.</param>
        private static string Format(int days)
        {
            if (days < 14)
            {
                return Unit(days, "day");
            }
            if (days < 60)
            {
                return Unit(days / 7.0, "week");
            }
            if (days < 730)
            {
                return Unit(days / 30.44, "month");
            }
            return Unit(days / 365.25, "year");
        }

        /// <summary>
        /// Formats an amount to one decimal place with a singular or plural unit.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="unit">The singular unit name.</param>
        private static string Unit(double amount, string unit)
        {
            string text = amount.ToString("0.#");
            return text == "1" ? $"1 {unit}" : $"{text} {unit}s";
        }
    }
}