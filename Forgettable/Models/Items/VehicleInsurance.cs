using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A vehicle insurance policy.
    /// </summary>
    [DisplayName("Vehicle Insurance")]
    public class VehicleInsurance : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Driving;

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
        /// The registration of the insured vehicle.
        /// </summary>
        [Display(Name = "Registration")]
        public string Registration { get; set; } = string.Empty;

        /// <summary>
        /// The date to start comparing quotes, 4 weeks before renewal.
        /// </summary>
        public DateOnly ShopAroundDate => ExpiryDate.AddDays(-28);

        /// <summary>
        /// Vehicle insurance is due from the shop around date.
        /// </summary>
        public override DateOnly UnbookedDueDate => ShopAroundDate;

        /// <summary>
        /// Why vehicle insurance is due early.
        /// </summary>
        public override string? DueDateReason => "Quotes from other providers are usually cheapest 3-4 weeks before renewal.";
    }
}