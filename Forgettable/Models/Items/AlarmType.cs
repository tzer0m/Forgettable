using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// The type of alarm.
    /// </summary>
    public enum AlarmType
    {
        /// <summary>
        /// A smoke alarm.
        /// </summary>
        Smoke,

        /// <summary>
        /// A carbon monoxide alarm.
        /// </summary>
        [Display(Name = "Carbon Monoxide")]
        CarbonMonoxide,

        /// <summary>
        /// A heat alarm.
        /// </summary>
        Heat
    }
}