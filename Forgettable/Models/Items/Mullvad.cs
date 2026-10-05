namespace Forgettable.Models.Items
{
    /// <summary>
    /// A prepaid Mullvad VPN account.
    /// </summary>
    public class Mullvad : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.IT;

        /// <summary>
        /// The date to renew, 2 days before expiry.
        /// </summary>
        public DateOnly RenewByDate => ExpiryDate.AddDays(-2);

        /// <summary>
        /// The account is due from the renew by date.
        /// </summary>
        public override DateOnly UnbookedDueDate => RenewByDate;

        /// <summary>
        /// Why the account is due early.
        /// </summary>
        public override string? DueDateReason => "Leave time to top up or renew before it runs out.";
    }
}