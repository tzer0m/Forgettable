using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A prepaid subscription, such as a VPN.
    /// </summary>
    public class Subscription : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Finance;

        /// <summary>
        /// The subscription provider, e.g. Mullvad.
        /// </summary>
        [Display(Name = "Provider")]
        public string Provider { get; set; } = string.Empty;

        /// <summary>
        /// The plan, e.g. 12 months.
        /// </summary>
        [Display(Name = "Plan")]
        public string Plan { get; set; } = string.Empty;

        /// <summary>
        /// The date to renew, a day before expiry.
        /// </summary>
        public DateOnly RenewByDate => ExpiryDate.AddDays(-2);

        /// <summary>
        /// The subscription is due from the renew by date.
        /// </summary>
        public override DateOnly UnbookedDueDate => RenewByDate;

        /// <summary>
        /// Why the subscription is due early.
        /// </summary>
        public override string? DueDateReason => "Leave time to top up or renew before it runs out.";
    }
}