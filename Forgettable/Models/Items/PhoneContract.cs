using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A mobile phone contract.
    /// </summary>
    [DisplayName("Phone Contract")]
    public class PhoneContract : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Contracts;

        /// <summary>
        /// The mobile network.
        /// </summary>
        [Display(Name = "Network")]
        public string Network { get; set; } = string.Empty;

        /// <summary>
        /// The date to start looking at deals, 2 weeks before the contract ends.
        /// </summary>
        public DateOnly ShopAroundDate => ExpiryDate.AddDays(-14);

        /// <summary>
        /// The contract is due from the shop around date.
        /// </summary>
        public override DateOnly UnbookedDueDate => ShopAroundDate;

        /// <summary>
        /// Why the contract is due early.
        /// </summary>
        public override string? DueDateReason => "Out of contract you usually pay more, so haggle or switch before it ends.";
    }
}