using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A smoke, carbon monoxide or heat alarm with a replace-by date.
    /// </summary>
    public class Alarm : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Property;

        /// <summary>
        /// The type of alarm.
        /// </summary>
        [Display(Name = "Alarm Type")]
        public AlarmType AlarmType { get; set; }

        /// <summary>
        /// The date to buy a replacement, 2 weeks before the replace-by date.
        /// </summary>
        public DateOnly BuyByDate => ExpiryDate.AddDays(-14);

        /// <summary>
        /// The alarm is due from the buy by date.
        /// </summary>
        public override DateOnly UnbookedDueDate => BuyByDate;

        /// <summary>
        /// Why the alarm is due early.
        /// </summary>
        public override string? DueDateReason => "Leave time to buy a replacement before it starts chirping.";
    }
}