using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models
{
    /// <summary>
    /// A UK Global Health Insurance Card.
    /// </summary>
    public class GHIC : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Travel;

        /// <summary>
        /// The personal ID number on the card.
        /// </summary>
        [Display(Name = "Personal ID Number")]
        public string PersonalIdNumber { get; set; } = string.Empty;

        /// <summary>
        /// The date to apply for a new card, a month before expiry.
        /// </summary>
        public DateOnly ApplyByDate => ExpiryDate.AddMonths(-1);

        /// <summary>
        /// The GHIC is due from the apply by date.
        /// </summary>
        public override DateOnly UnbookedDueDate => ApplyByDate;

        /// <summary>
        /// Why the GHIC is due early.
        /// </summary>
        public override string? DueDateReason => "A new card can take a couple of weeks to arrive.";
    }
}