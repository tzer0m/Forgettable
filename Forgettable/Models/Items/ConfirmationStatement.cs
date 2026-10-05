using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A Companies House confirmation statement, with the filing deadline as the expiry date.
    /// </summary>
    [DisplayName("Confirmation")]
    public class ConfirmationStatement : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Business;

        /// <summary>
        /// The Companies House company number.
        /// </summary>
        [Display(Name = "Company Number")]
        public string CompanyNumber { get; set; } = string.Empty;

        /// <summary>
        /// The date to check with the accountant, a week before the deadline.
        /// </summary>
        public DateOnly CheckByDate => ExpiryDate.AddDays(-7);

        /// <summary>
        /// The statement is due from the check by date.
        /// </summary>
        public override DateOnly UnbookedDueDate => CheckByDate;

        /// <summary>
        /// Why the statement is due early.
        /// </summary>
        public override string? DueDateReason => "Leave time to check with the accountant before the filing deadline.";
    }
}