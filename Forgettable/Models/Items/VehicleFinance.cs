using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// A vehicle finance agreement.
    /// </summary>
    [DisplayName("Vehicle Finance")]
    public class VehicleFinance : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.Vehicle;

        /// <summary>
        /// The type of finance agreement.
        /// </summary>
        [Display(Name = "Finance Type")]
        public FinanceType FinanceType { get; set; }

        /// <summary>
        /// The finance company.
        /// </summary>
        public string Lender { get; set; } = string.Empty;

        /// <summary>
        /// The agreement number.
        /// </summary>
        [Display(Name = "Agreement Number")]
        public string AgreementNumber { get; set; } = string.Empty;

        /// <summary>
        /// The vehicle's registration number.
        /// </summary>
        public string Registration { get; set; } = string.Empty;

        /// <summary>
        /// The optional final payment on a PCP agreement.
        /// </summary>
        [Display(Name = "Final Payment")]
        public decimal? FinalPayment { get; set; }

        /// <summary>
        /// The annual mileage allowance on a PCP or lease agreement.
        /// </summary>
        [Display(Name = "Mileage Allowance")]
        public int? MileageAllowance { get; set; }

        /// <summary>
        /// Whether the agreement type has a final payment.
        /// </summary>
        public bool HasFinalPayment => FinanceType == FinanceType.PCP;

        /// <summary>
        /// Whether the agreement type has a mileage allowance.
        /// </summary>
        public bool HasMileageAllowance => FinanceType is FinanceType.PCP or FinanceType.Lease;

        /// <summary>
        /// The date to start deciding what to do at the end, 3 months before it ends.
        /// </summary>
        public DateOnly DecideByDate => ExpiryDate.AddMonths(-3);

        /// <summary>
        /// PCP and leases are due from the decide by date, HP and loans on the end date.
        /// </summary>
        public override DateOnly UnbookedDueDate => FinanceType is FinanceType.PCP or FinanceType.Lease ? DecideByDate : ExpiryDate;

        /// <summary>
        /// Why the finance agreement is due early.
        /// </summary>
        public override string? DueDateReason => FinanceType switch { FinanceType.PCP => "Leave time to decide whether to pay the final payment, hand the car back or part-exchange.", FinanceType.Lease => "Leave time to arrange the next car before this one goes back.", _ => null };
    }
}