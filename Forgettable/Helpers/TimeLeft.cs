namespace Forgettable.Helpers
{
    /// <summary>
    /// Describes how long is left until a date in the most readable unit.
    /// </summary>
    public static class TimeLeft
    {
        /// <summary>
        /// Returns the time left until a date, e.g. "5d", "3.5w", or "-2w" when overdue.
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
            return days < 0 ? $"-{amount}" : amount;
        }

        /// <summary>
        /// Formats a number of days as days (d), weeks (w), months (m) or years (y).
        /// </summary>
        /// <param name="days">The number of days.</param>
        private static string Format(int days)
        {
            if (days < 7)
            {
                return Unit(days, "d");
            }
            if (days < 30)
            {
                return Unit(days / 7.0, "w");
            }
            if (days < 365)
            {
                return Unit(days / 30.44, "m");
            }
            return Unit(days / 365.25, "y");
        }

        /// <summary>
        /// Formats an amount to one decimal place followed by its unit letter, e.g. "3.5w".
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="unit">The unit letter.</param>
        private static string Unit(double amount, string unit)
        {
            return $"{amount:0.#}{unit}";
        }
    }
}