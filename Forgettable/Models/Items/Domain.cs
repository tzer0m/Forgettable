using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A domain name registration.
    /// </summary>
    public class Domain : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.IT;

        /// <summary>
        /// The domain registrar.
        /// </summary>
        [Display(Name = "Registrar")]
        public string Registrar { get; set; } = string.Empty;

        /// <summary>
        /// The date to renew, a month before expiry.
        /// </summary>
        public DateOnly RenewByDate => ExpiryDate.AddMonths(-1);

        /// <summary>
        /// The domain is due from the renew by date.
        /// </summary>
        public override DateOnly UnbookedDueDate => RenewByDate;

        /// <summary>
        /// Why the domain is due early.
        /// </summary>
        public override string? DueDateReason => "If a domain lapses, its websites and email stop working, so leave time to sort out payment problems.";
    }
}