using Forgettable.Data;
using Forgettable.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Forgettable.Pages
{
    /// <summary>
    /// Page model for confirming and deleting an item.
    /// </summary>
    /// <param name="db">The database context.</param>
    public class DeleteModel(ForgettableDbContext db) : PageModel
    {
        /// <summary>
        /// The item being deleted.
        /// </summary>
        public Item Item { get; set; } = null!;

        /// <summary>
        /// The friendly name of the item type.
        /// </summary>
        public string TypeName { get; set; } = string.Empty;

        /// <summary>
        /// Shows the delete confirmation.
        /// </summary>
        /// <param name="id">The item's ID.</param>
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Item? item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            Item = item;
            TypeName = ItemTypes.GetDisplayName(item.GetType());
            return Page();
        }

        /// <summary>
        /// Deletes the item.
        /// </summary>
        /// <param name="id">The item's ID.</param>
        public async Task<IActionResult> OnPostAsync(int id)
        {
            Item? item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            db.Items.Remove(item);
            await db.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}