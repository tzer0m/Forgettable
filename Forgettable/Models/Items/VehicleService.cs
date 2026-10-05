using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A vehicle's service.
    /// </summary>
    [DisplayName("Vehicle Service")]
    public class VehicleService : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Driving;

        /// <summary>
        /// The vehicle's registration number.
        /// </summary>
        [Display(Name = "Registration")]
        public string Registration { get; set; } = string.Empty;

        /// <summary>
        /// The date to book the service, 2 months before it's due.
        /// </summary>
        public DateOnly BookByDate => ExpiryDate.AddMonths(-2);

        /// <summary>
        /// The service is due from the book by date.
        /// </summary>
        public override DateOnly UnbookedDueDate => BookByDate;

        /// <summary>
        /// Why the service is due early.
        /// </summary>
        public override string? DueDateReason => "Garages can get booked up, so book ahead.";
    }
}