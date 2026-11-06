using Forgettable.Data;
using Forgettable.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Forgettable.Endpoints
{
    /// <summary>
    /// The API key protected endpoint that feeds the Tidgets home screen widget.
    /// </summary>
    public static class WidgetEndpoint
    {
        /// <summary>
        /// Returns the next item due as JSON, or 401 if the API key is missing or wrong.
        /// </summary>
        /// <param name="request">The HTTP request, for the API key header.</param>
        /// <param name="db">The database context.</param>
        /// <param name="configuration">Used to read the expected API key.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public static async Task<IResult> GetAsync(HttpRequest request, ForgettableDbContext db, IConfiguration configuration, CancellationToken cancellationToken)
        {
            string? expected = configuration["Widget:ApiKey"];
            string provided = request.Headers["X-Api-Key"].ToString();
            if (string.IsNullOrEmpty(expected) || !CryptographicOperations.FixedTimeEquals(Encoding.UTF8.GetBytes(provided), Encoding.UTF8.GetBytes(expected)))
            {
                return Results.Unauthorized();
            }
            List<Item> items = await db.Items.AsNoTracking().Where(x => !x.Archived && !x.Booked).ToListAsync(cancellationToken);
            Item? next = items.OrderBy(x => x.DueDate).FirstOrDefault();
            return Results.Ok(new WidgetResponse { Next = next is null ? null : new WidgetItem { Subject = next.Subject, Type = ItemTypes.GetDisplayName(next.GetType()), DueDate = next.DueDate } });
        }
    }
}