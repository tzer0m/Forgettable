using Forgettable.Data;
using Forgettable.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Forgettable.Pages
{
    /// <summary>
    /// Page model for editing an existing item.
    /// </summary>
    /// <param name="db">The database context.</param>
    public class EditModel(ForgettableDbContext db) : PageModel
    {
        /// <summary>
        /// The item being edited.
        /// </summary>
        public Item Item { get; set; } = null!;

        /// <summary>
        /// The friendly name of the item type.
        /// </summary>
        public string TypeName { get; set; } = string.Empty;

        /// <summary>
        /// Shows the form filled with the item's current values.
        /// </summary>
        /// <param name="id">The item's ID.</param>
        public async Task<IActionResult> OnGetAsync(int id)
        {
            return await Load(id) ? Page() : NotFound();
        }

        /// <summary>
        /// Binds the posted form onto the item and saves it.
        /// </summary>
        /// <param name="id">The item's ID.</param>
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!await Load(id))
            {
                return NotFound();
            }
            if (!await TryUpdateModelAsync(Item, Item.GetType(), nameof(Item)))
            {
                return Page();
            }
            await db.SaveChangesAsync();
            return RedirectToPage("/Index");
        }

        /// <summary>
        /// Loads the item and its type name.
        /// </summary>
        /// <param name="id">The item's ID.</param>
        private async Task<bool> Load(int id)
        {
            Item? item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return false;
            }
            Item = item;
            TypeName = ItemTypes.GetDisplayName(item.GetType());
            return true;
        }
    }
}