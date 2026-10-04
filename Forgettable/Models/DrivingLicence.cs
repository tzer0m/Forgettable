using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models
{
    /// <summary>
    /// A driving licence photocard.
    /// </summary>
    [DisplayName("Driving Licence")]
    public class DrivingLicence : Item
    {
        /// <summary>
        /// The driver number.
        /// </summary>
        [Display(Name = "Driver Number")]
        public string DriverNumber { get; set; } = string.Empty;
    }
}