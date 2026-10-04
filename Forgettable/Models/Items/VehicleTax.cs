using System.ComponentModel;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A vehicle's road tax.
    /// </summary>
    [DisplayName("Vehicle Tax")]
    public class VehicleTax : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Vehicle;

        /// <summary>
        /// The vehicle's registration number.
        /// </summary>
        public string Registration { get; set; } = string.Empty;

        /// <summary>
        /// The earliest date the tax can be renewed, the 1st of the month it runs out.
        /// </summary>
        public DateOnly RenewFromDate => new(ExpiryDate.Year, ExpiryDate.Month, 1);

        /// <summary>
        /// Vehicle tax is due from the renew from date.
        /// </summary>
        public override DateOnly UnbookedDueDate => RenewFromDate;

        /// <summary>
        /// Why vehicle tax is due early.
        /// </summary>
        public override string? DueDateReason => "Vehicle tax can be renewed from the 1st of the month it runs out.";
    }
}