using System.ComponentModel;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A chimney sweep.
    /// </summary>
    [DisplayName("Chimney Sweep")]
    public class ChimneySweep : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Property;

        /// <summary>
        /// The date to book the sweep, 2 months before it's due.
        /// </summary>
        public DateOnly BookByDate => ExpiryDate.AddMonths(-2);

        /// <summary>
        /// The chimney sweep is due from the book by date.
        /// </summary>
        public override DateOnly UnbookedDueDate => BookByDate;

        /// <summary>
        /// Why the chimney sweep is due early.
        /// </summary>
        public override string? DueDateReason => "Chimney sweeps often need booking around 2 months in advance.";
    }
}