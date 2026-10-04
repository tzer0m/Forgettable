using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A mortgage's fixed rate period.
    /// </summary>
    public class Mortgage : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Property;

        /// <summary>
        /// The mortgage lender.
        /// </summary>
        public string Lender { get; set; } = string.Empty;

        /// <summary>
        /// The mortgage account number.
        /// </summary>
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; } = string.Empty;

        /// <summary>
        /// The current fixed interest rate, as a percentage.
        /// </summary>
        public decimal? Rate { get; set; }

        /// <summary>
        /// The date a new deal can usually be locked in, 6 months before the fixed rate ends.
        /// </summary>
        public DateOnly LockInFromDate => ExpiryDate.AddMonths(-6);

        /// <summary>
        /// The mortgage is due from the lock in from date.
        /// </summary>
        public override DateOnly UnbookedDueDate => LockInFromDate;

        /// <summary>
        /// Why the mortgage is due early.
        /// </summary>
        public override string? DueDateReason => "You can usually lock in a new deal up to 6 months before your fixed rate ends.";
    }
}