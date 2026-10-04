using Forgettable.Data;
using Forgettable.Helpers;
using Forgettable.Models;
using Forgettable.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace Forgettable.Endpoints
{
    /// <summary>
    /// Serves the calendar feed to calendar apps, protected by a secret token instead of a login.
    /// </summary>
    public static class CalendarEndpoint
    {
        /// <summary>
        /// Returns the iCalendar feed if the token matches, otherwise not found.
        /// </summary>
        /// <param name="token">The token from the URL.</param>
        /// <param name="options">The calendar settings.</param>
        /// <param name="db">The database context.</param>
        /// <param name="request">The current request, used to build links back to the site.</param>
        public static async Task<IResult> GetAsync(string token, IOptions<CalendarOptions> options, ForgettableDbContext db, HttpRequest request)
        {
            string expected = options.Value.Token;
            if (string.IsNullOrEmpty(expected) || !CryptographicOperations.FixedTimeEquals(Encoding.UTF8.GetBytes(token), Encoding.UTF8.GetBytes(expected)))
            {
                return Results.NotFound();
            }
            List<Item> items = await db.Items.AsNoTracking().Where(x => !x.Archived && !x.Booked).ToListAsync();
            string baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";
            return Results.Text(CalendarFeed.Build(items, baseUrl), "text/calendar; charset=utf-8");
        }
    }
}