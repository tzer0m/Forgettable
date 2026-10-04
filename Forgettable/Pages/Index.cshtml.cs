using Forgettable.Data;
using Forgettable.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Forgettable.Pages
{
    /// <summary>
    /// Page model for the dashboard.
    /// </summary>
    /// <param name="db">The database context.</param>
    public class IndexModel(ForgettableDbContext db) : PageModel
    {
        /// <summary>
        /// The items to display, soonest due first.
        /// </summary>
        public List<Item> Items { get; set; } = [];

        /// <summary>
        /// Loads all items from the database.
        /// </summary>
        public async Task OnGetAsync()
        {
            List<Item> items = await db.Items.AsNoTracking().ToListAsync();
            Items = [.. items.OrderBy(x => x.DueDate)];
        }
    }
}