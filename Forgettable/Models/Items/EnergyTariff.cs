using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A fixed energy tariff.
    /// </summary>
    [DisplayName("Energy Tariff")]
    public class EnergyTariff : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Property;

        /// <summary>
        /// The energy supplier.
        /// </summary>
        [Display(Name = "Supplier")]
        public string Supplier { get; set; } = string.Empty;

        /// <summary>
        /// The supplier account number.
        /// </summary>
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; } = string.Empty;

        /// <summary>
        /// The first date a switch has no exit fees, 49 days before the tariff ends.
        /// </summary>
        public DateOnly SwitchFromDate => ExpiryDate.AddDays(-49);

        /// <summary>
        /// The tariff is due from the switch from date.
        /// </summary>
        public override DateOnly UnbookedDueDate => SwitchFromDate;

        /// <summary>
        /// Why the tariff is due early.
        /// </summary>
        public override string? DueDateReason => "Ofgem rules let you switch in the last 49 days of a fixed tariff without exit fees.";
    }
}