using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A professional indemnity or business insurance policy.
    /// </summary>
    [DisplayName("Professional Insurance")]
    public class ProfessionalInsurance : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Business;

        /// <summary>
        /// The insurance provider.
        /// </summary>
        [Display(Name = "Provider")]
        public string Provider { get; set; } = string.Empty;

        /// <summary>
        /// The policy number.
        /// </summary>
        [Display(Name = "Policy Number")]
        public string PolicyNumber { get; set; } = string.Empty;

        /// <summary>
        /// The date to start comparing quotes, 4 weeks before renewal.
        /// </summary>
        [Display(Name = "Shop Around From")]
        public DateOnly ShopAroundDate => ExpiryDate.AddDays(-28);

        /// <summary>
        /// Professional insurance is due from the shop around date.
        /// </summary>
        public override DateOnly UnbookedDueDate => ShopAroundDate;

        /// <summary>
        /// Why professional insurance is due early.
        /// </summary>
        public override string? DueDateReason => "Leave time to get quotes from other providers before it renews.";
    }
}