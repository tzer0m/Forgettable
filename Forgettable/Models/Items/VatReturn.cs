using System.ComponentModel;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A quarterly VAT return, with the filing deadline as the expiry date.
    /// </summary>
    [DisplayName("VAT Return")]
    public class VatReturn : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Business;

        /// <summary>
        /// The date to check with the accountant, a week before the deadline.
        /// </summary>
        public DateOnly CheckByDate => ExpiryDate.AddDays(-7);

        /// <summary>
        /// The return is due from the check by date.
        /// </summary>
        public override DateOnly UnbookedDueDate => CheckByDate;

        /// <summary>
        /// Why the return is due early.
        /// </summary>
        public override string? DueDateReason => "Leave time to check with the accountant before the filing deadline.";
    }
}