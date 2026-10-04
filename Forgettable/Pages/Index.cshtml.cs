using Forgettable.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Forgettable.Pages
{
    /// <summary>
    /// Page model for the dashboard.
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// The items to display, soonest due first.
        /// </summary>
        public List<Item> Items { get; set; } = [];

        /// <summary>
        /// Loads the dashboard with sample items until the database is in place.
        /// </summary>
        public void OnGet()
        {
            List<Item> items =
            [
                new Passport { ItemId = 1, Name = "Tom's Passport", ExpiryDate = new DateOnly(2031, 3, 14) },
                new DrivingLicence { ItemId = 2, Name = "Tom's Driving Licence", ExpiryDate = new DateOnly(2029, 8, 2), DriverNumber = "ODDY9801010T99AB" },
                new Mot { ItemId = 3, Name = "Car MOT", ExpiryDate = new DateOnly(2026, 11, 20), Registration = "AB12 CDE" }
            ];
            Items = [.. items.OrderBy(x => x.DueDate)];
        }
    }
}