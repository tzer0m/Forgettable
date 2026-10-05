using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A vehicle's MOT.
    /// </summary>
    public class MOT : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Driving;

        /// <summary>
        /// The vehicle's registration number.
        /// </summary>
        [Display(Name = "Registration")]
        public string Registration { get; set; } = string.Empty;

        /// <summary>
        /// The earliest test date that keeps the current anniversary date.
        /// </summary>
        [Display(Name = "Earliest Test")]
        public DateOnly EarliestTestDate => ExpiryDate.AddMonths(-1).AddDays(1);

        /// <summary>
        /// The MOT is due from the earliest test date.
        /// </summary>
        public override DateOnly UnbookedDueDate => EarliestTestDate;

        /// <summary>
        /// Why the MOT is due early.
        /// </summary>
        public override string? DueDateReason => "An MOT can be done up to a month minus a day early and still keep the same renewal date.";
    }
}