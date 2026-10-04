using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A driving licence photocard.
    /// </summary>
    [DisplayName("Driving Licence")]
    public class DrivingLicence : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Travel;

        /// <summary>
        /// The licence number.
        /// </summary>
        [Display(Name = "Licence Number")]
        public string LicenceNumber { get; set; } = string.Empty;
    }
}