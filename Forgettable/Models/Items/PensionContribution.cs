using System.ComponentModel;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// An employer pension contribution from the company, with the company year end as the expiry date.
    /// </summary>
    [DisplayName("Pension Contribution")]
    public class PensionContribution : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Business;

        /// <summary>
        /// The date to pay the contribution, 2 weeks before the deadline.
        /// </summary>
        public DateOnly PayByDate => ExpiryDate.AddDays(-14);

        /// <summary>
        /// The contribution is due from the pay by date.
        /// </summary>
        public override DateOnly UnbookedDueDate => PayByDate;

        /// <summary>
        /// Why the contribution is due early.
        /// </summary>
        public override string? DueDateReason => "Leave time for the payment to reach the provider before the deadline.";
    }
}