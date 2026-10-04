using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A home or contents insurance policy.
    /// </summary>
    [DisplayName("Home Insurance")]
    public class HomeInsurance : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Property;

        /// <summary>
        /// The insurance provider.
        /// </summary>
        public string Provider { get; set; } = string.Empty;

        /// <summary>
        /// The policy number.
        /// </summary>
        [Display(Name = "Policy Number")]
        public string PolicyNumber { get; set; } = string.Empty;

        /// <summary>
        /// The date to start comparing quotes, 4 weeks before renewal.
        /// </summary>
        public DateOnly ShopAroundDate => ExpiryDate.AddDays(-28);

        /// <summary>
        /// Home insurance is due from the shop around date.
        /// </summary>
        public override DateOnly UnbookedDueDate => ShopAroundDate;

        /// <summary>
        /// Why home insurance is due early.
        /// </summary>
        public override string? DueDateReason => "Quotes from other providers are usually cheapest 3-4 weeks before renewal.";
    }
}