using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// An API token or personal access token, such as a GitHub token.
    /// </summary>
    [DisplayName("API Token")]
    public class ApiToken : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.IT;

        /// <summary>
        /// The service that issued the token, e.g. GitHub or Cloudflare.
        /// </summary>
        [Display(Name = "Service")]
        public string Service { get; set; } = string.Empty;

        /// <summary>
        /// What uses the token and needs updating when it is replaced.
        /// </summary>
        [Display(Name = "Used By")]
        public string UsedBy { get; set; } = string.Empty;

        /// <summary>
        /// The date to replace the token, 2 weeks before expiry.
        /// </summary>
        public DateOnly ReplaceByDate => ExpiryDate.AddDays(-14);

        /// <summary>
        /// The token is due from the replace by date.
        /// </summary>
        public override DateOnly UnbookedDueDate => ReplaceByDate;

        /// <summary>
        /// Why the token is due early.
        /// </summary>
        public override string? DueDateReason => "Leave time to create a new token and update everywhere it's used.";
    }
}