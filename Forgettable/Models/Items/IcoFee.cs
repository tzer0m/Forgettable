using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// The yearly ICO data protection fee.
    /// </summary>
    [DisplayName("ICO Fee")]
    public class IcoFee : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Business;

        /// <summary>
        /// The ICO registration number, e.g. ZA123456.
        /// </summary>
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; } = string.Empty;

        /// <summary>
        /// The date to renew, a week before expiry.
        /// </summary>
        public DateOnly RenewByDate => ExpiryDate.AddDays(-7);

        /// <summary>
        /// The fee is due from the renew by date.
        /// </summary>
        public override DateOnly UnbookedDueDate => RenewByDate;

        /// <summary>
        /// Why the fee is due early.
        /// </summary>
        public override string? DueDateReason => "Leave time to renew so the company stays on the ICO register.";
    }
}