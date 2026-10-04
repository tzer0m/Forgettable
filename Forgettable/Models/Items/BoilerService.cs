using System.ComponentModel;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A boiler service.
    /// </summary>
    [DisplayName("Boiler Service")]
    public class BoilerService : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Property;

        /// <summary>
        /// The date to book the service, a month before it's due.
        /// </summary>
        public DateOnly BookByDate => ExpiryDate.AddMonths(-1);

        /// <summary>
        /// The boiler service is due from the book by date.
        /// </summary>
        public override DateOnly UnbookedDueDate => BookByDate;

        /// <summary>
        /// Why the boiler service is due early.
        /// </summary>
        public override string? DueDateReason => "Engineers get busy in autumn and winter, so book ahead.";
    }
}