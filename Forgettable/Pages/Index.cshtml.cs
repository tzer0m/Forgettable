using Forgettable.Data;
using Forgettable.Models;
using Microsoft.AspNetCore.Mvc;
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
        /// The items to display, soonest due first with archived items last.
        /// </summary>
        public List<Item> Items { get; set; } = [];

        /// <summary>
        /// Loads all items from the database.
        /// </summary>
        public async Task OnGetAsync()
        {
            List<Item> items = await db.Items.AsNoTracking().ToListAsync();
            Items = [.. items.OrderBy(x => x.Archived).ThenBy(x => x.DueDate)];
        }

        /// <summary>
        /// Archives or unarchives an item.
        /// </summary>
        /// <param name="id">The item's ID.</param>
        public async Task<IActionResult> OnPostArchiveAsync(int id)
        {
            Item? item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Archived = !item.Archived;
            await db.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}