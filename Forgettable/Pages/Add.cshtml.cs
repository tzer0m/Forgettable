using Forgettable.Data;
using Forgettable.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Forgettable.Pages
{
    /// <summary>
    /// Page model for adding an item of a given type.
    /// </summary>
    /// <param name="db">The database context.</param>
    public class AddModel(ForgettableDbContext db) : PageModel
    {
        /// <summary>
        /// The item being added.
        /// </summary>
        public Item Item { get; set; } = null!;

        /// <summary>
        /// The friendly name of the item type.
        /// </summary>
        public string TypeName { get; set; } = string.Empty;

        /// <summary>
        /// Shows a blank form for the requested type.
        /// </summary>
        /// <param name="type">The item type's class name.</param>
        public IActionResult OnGet(string type)
        {
            if (!ItemTypes.All.TryGetValue(type, out Type? itemType))
            {
                return NotFound();
            }
            Create(itemType);
            Item.ExpiryDate = DateOnly.FromDateTime(DateTime.Today);
            return Page();
        }

        /// <summary>
        /// Binds the posted form onto the item type and saves it.
        /// </summary>
        /// <param name="type">The item type's class name.</param>
        public async Task<IActionResult> OnPostAsync(string type)
        {
            if (!ItemTypes.All.TryGetValue(type, out Type? itemType))
            {
                return NotFound();
            }
            Create(itemType);
            if (!await TryUpdateModelAsync(Item, itemType, nameof(Item)))
            {
                return Page();
            }
            db.Items.Add(Item);
            await db.SaveChangesAsync();
            return RedirectToPage("/Index");
        }

        /// <summary>
        /// Creates a new instance of the item type.
        /// </summary>
        /// <param name="itemType">The item type.</param>
        private void Create(Type itemType)
        {
            Item = (Item)Activator.CreateInstance(itemType)!;
            TypeName = ItemTypes.GetDisplayName(itemType);
        }
    }
}