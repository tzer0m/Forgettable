using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A company's Corporation Tax, with the payment deadline as the expiry date.
    /// </summary>
    [DisplayName("Corporation Tax")]
    public class CorporationTax : Item
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
        /// The accounting period the tax covers, e.g. Nov 2025 – Oct 2026.
        /// </summary>
        [Display(Name = "Accounting Period")]
        public string AccountingPeriod { get; set; } = string.Empty;

        /// <summary>
        /// The date to check with the accountant, a week before the payment deadline.
        /// </summary>
        public DateOnly CheckByDate => ExpiryDate.AddDays(-7);

        /// <summary>
        /// The tax is due from the check by date.
        /// </summary>
        public override DateOnly UnbookedDueDate => CheckByDate;

        /// <summary>
        /// Why the tax is due early.
        /// </summary>
        public override string? DueDateReason => "Leave time to check with the accountant before the payment deadline.";
    }
}