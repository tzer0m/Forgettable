namespace Forgettable.Models.Items
{
    /// <summary>
    /// The type of vehicle finance agreement.
    /// </summary>
    public enum FinanceType
    {
        /// <summary>
        /// Personal contract purchase, with an optional final payment.
        /// </summary>
        PCP,

        /// <summary>
        /// Hire purchase, owned outright after the last payment.
        /// </summary>
        HP,

        /// <summary>
        /// A lease, returned at the end.
        /// </summary>
        Lease,

        /// <summary>
        /// A fixed sum loan, owned from the start.
        /// </summary>
        Loan
    }
}