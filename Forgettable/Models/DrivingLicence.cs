namespace Forgettable.Models
{
    /// <summary>
    /// A driving licence photocard.
    /// </summary>
    public class DrivingLicence : Item
    {
        /// <summary>
        /// The driver number.
        /// </summary>
        public string DriverNumber { get; set; } = string.Empty;
    }
}