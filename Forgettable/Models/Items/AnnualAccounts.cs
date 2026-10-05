using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A company's annual accounts, with the filing deadline as the expiry date.
    /// </summary>
    [DisplayName("Annual Accounts")]
    public class AnnualAccounts : Item
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
        /// The accounts are due from the check by date.
        /// </summary>
        public override DateOnly UnbookedDueDate => CheckByDate;

        /// <summary>
        /// Why the accounts are due early.
        /// </summary>
        public override string? DueDateReason => "Leave time to check with the accountant before the filing deadline.";
    }
}