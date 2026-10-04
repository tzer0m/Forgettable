using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A National Rail railcard.
    /// </summary>
    public class Railcard : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Travel;

        /// <summary>
        /// The type of railcard, e.g. 26-30 or Two Together.
        /// </summary>
        [Display(Name = "Type")]
        public string RailcardType { get; set; } = string.Empty;

        /// <summary>
        /// The railcard number.
        /// </summary>
        [Display(Name = "Number")]
        public string RailcardNumber { get; set; } = string.Empty;

        /// <summary>
        /// The date to renew, a week before expiry.
        /// </summary>
        public DateOnly RenewByDate => ExpiryDate.AddDays(-7);

        /// <summary>
        /// The railcard is due from the renew by date.
        /// </summary>
        public override DateOnly UnbookedDueDate => RenewByDate;

        /// <summary>
        /// Why the railcard is due early.
        /// </summary>
        public override string? DueDateReason => "Renew in advance so there's no gap in discounted fares.";
    }
}