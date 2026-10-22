using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A motorcycle Compulsory Basic Training certificate.
    /// </summary>
    public class CBT : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Driving;

        /// <summary>
        /// The DL196 certificate number.
        /// </summary>
        [Display(Name = "Certificate Number")]
        public string CertificateNumber { get; set; } = string.Empty;

        /// <summary>
        /// The CBT is due two months before it expires, leaving time to book a new one.
        /// </summary>
        public override DateOnly UnbookedDueDate => ExpiryDate.AddMonths(-2);

        /// <summary>
        /// Why the CBT is due early.
        /// </summary>
        public override string? DueDateReason => "Due two months early to leave time to book a new CBT.";
    }
}