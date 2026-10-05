using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A personal Self Assessment tax return, with the filing deadline as the expiry date.
    /// </summary>
    [DisplayName("Self Assessment")]
    public class SelfAssessment : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Finance;

        /// <summary>
        /// The tax year the return covers, e.g. 2025/26.
        /// </summary>
        [Display(Name = "Tax Year")]
        public string TaxYear { get; set; } = string.Empty;

        /// <summary>
        /// The date to check with the accountant, a month before the deadline.
        /// </summary>
        public DateOnly CheckByDate => ExpiryDate.AddMonths(-1);

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