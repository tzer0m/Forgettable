namespace Forgettable.Models
{
    /// <summary>
    /// A passport.
    /// </summary>
    public class Passport : Item
    {
        /// <summary>
        /// The last date the passport has 6 months of validity left.
        /// </summary>
        public DateOnly EffectiveExpiryDate => ExpiryDate.AddMonths(-6);

        /// <summary>
        /// The passport is due from its effective expiry date.
        /// </summary>
        public override DateOnly DueDate => EffectiveExpiryDate;
    }
}