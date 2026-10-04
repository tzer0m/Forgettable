using Forgettable.Models;
using System.Text;

namespace Forgettable.Helpers
{
    /// <summary>
    /// Builds an iCalendar feed with an all-day event on each item's due date.
    /// </summary>
    public static class CalendarFeed
    {
        /// <summary>
        /// Returns the iCalendar text for the active, unbooked items.
        /// </summary>
        /// <param name="items">The items to include; archived and booked items are skipped.</param>
        /// <param name="baseUrl">The site's base URL, used to link each event back to its item.</param>
        public static string Build(IEnumerable<Item> items, string baseUrl)
        {
            string stamp = DateTime.UtcNow.ToString("yyyyMMdd'T'HHmmss'Z'");
            List<string> lines = ["BEGIN:VCALENDAR", "VERSION:2.0", "PRODID:-//Forgettable//EN", "CALSCALE:GREGORIAN", "METHOD:PUBLISH", "X-WR-CALNAME:Forgettable", "REFRESH-INTERVAL;VALUE=DURATION:PT1H", "X-PUBLISHED-TTL:PT1H"];
            foreach (Item item in items.Where(x => !x.Archived && !x.Booked))
            {
                string url = $"{baseUrl.TrimEnd('/')}/#item-{item.ItemId}";
                string details = string.Join("\n", ItemDetails.Get(item).Select(x => $"{x.Label}: {x.Text}"));
                lines.Add("BEGIN:VEVENT");
                lines.Add($"UID:item-{item.ItemId}@forgettable");
                lines.Add($"DTSTAMP:{stamp}");
                lines.Add($"DTSTART;VALUE=DATE:{item.DueDate:yyyyMMdd}");
                lines.Add($"DTEND;VALUE=DATE:{item.DueDate.AddDays(1):yyyyMMdd}");
                lines.Add($"SUMMARY:{Escape($"{item.Subject} - {ItemTypes.GetDisplayName(item.GetType())}")}");
                lines.Add($"DESCRIPTION:{Escape($"{details}\n\n{url}")}");
                lines.Add($"URL:{url}");
                lines.Add("TRANSP:TRANSPARENT");
                lines.Add("END:VEVENT");
            }
            lines.Add("END:VCALENDAR");
            return string.Concat(lines.Select(x => Fold(x) + "\r\n"));
        }

        /// <summary>
        /// Escapes text for an iCalendar property value.
        /// </summary>
        /// <param name="text">The text to escape.</param>
        private static string Escape(string text)
        {
            return text.Replace("\\", "\\\\").Replace(";", "\\;").Replace(",", "\\,").Replace("\r\n", "\\n").Replace("\n", "\\n");
        }

        /// <summary>
        /// Folds a line so no part is longer than 75 bytes, as iCalendar requires.
        /// </summary>
        /// <param name="line">The line to fold.</param>
        private static string Fold(string line)
        {
            StringBuilder folded = new();
            int bytes = 0;
            foreach (char character in line)
            {
                int size = Encoding.UTF8.GetByteCount([character]);
                if (bytes + size > 75)
                {
                    folded.Append("\r\n ");
                    bytes = 1;
                }
                folded.Append(character);
                bytes += size;
            }
            return folded.ToString();
        }
    }
}