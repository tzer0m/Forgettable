using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// An internet contract.
    /// </summary>
    [DisplayName("Internet Contract")]
    public class InternetContract : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Property;

        /// <summary>
        /// The internet provider.
        /// </summary>
        [Display(Name = "Provider")]
        public string Provider { get; set; } = string.Empty;

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