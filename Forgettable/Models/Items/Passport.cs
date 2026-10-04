using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A passport.
    /// </summary>
    public class Passport : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Travel;

        /// <summary>
        /// The passport number.
        /// </summary>
        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; } = string.Empty;

        /// <summary>
        /// The last date the passport has 6 months of validity left.
        /// </summary>
        [Display(Name = "Effective Expiry")]
        public DateOnly EffectiveExpiryDate => ExpiryDate.AddMonths(-6);

        /// <summary>
        /// The passport is due from its effective expiry date.
        /// </summary>
        public override DateOnly UnbookedDueDate => EffectiveExpiryDate;

        /// <summary>
        /// Why the passport is due early.
        /// </summary>
        public override string? DueDateReason => "Many countries require at least 6 months of passport validity to enter.";
    }
}