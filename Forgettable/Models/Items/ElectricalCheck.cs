using System.ComponentModel;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// An electrical installation condition report (EICR).
    /// </summary>
    [DisplayName("Electrical Check")]
    public class ElectricalCheck : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Property;

        /// <summary>
        /// The date to book the check, a month before it's due.
        /// </summary>
        public DateOnly BookByDate => ExpiryDate.AddMonths(-1);

        /// <summary>
        /// The electrical check is due from the book by date.
        /// </summary>
        public override DateOnly UnbookedDueDate => BookByDate;

        /// <summary>
        /// Why the electrical check is due early.
        /// </summary>
        public override string? DueDateReason => "Leave time to book an electrician for the check.";
    }
}