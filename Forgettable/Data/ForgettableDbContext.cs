using Forgettable.Models;
using Forgettable.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace Forgettable.Data
{
    /// <summary>
    /// Database context for Forgettable.
    /// </summary>
    /// <param name="options">The database context options.</param>
    public class ForgettableDbContext(DbContextOptions<ForgettableDbContext> options) : DbContext(options)
    {
        /// <summary>
        /// All items, of every type.
        /// </summary>
        public DbSet<Item> Items { get; set; }

        /// <summary>
        /// Passports.
        /// </summary>
        public DbSet<Passport> Passports { get; set; }

        /// <summary>
        /// Driving licences.
        /// </summary>
        public DbSet<DrivingLicence> DrivingLicences { get; set; }

        /// <summary>
        /// MOTs.
        /// </summary>
        public DbSet<MOT> MOTs { get; set; }

        /// <summary>
        /// Chimney sweeps.
        /// </summary>
        public DbSet<ChimneySweep> ChimneySweeps { get; set; }

        /// <summary>
        /// Home insurance policies.
        /// </summary>
        public DbSet<HomeInsurance> HomeInsurances { get; set; }

        /// <summary>
        /// Global Health Insurance Cards.
        /// </summary>
        public DbSet<GHIC> GHICs { get; set; }

        /// <summary>
        /// Railcards.
        /// </summary>
        public DbSet<Railcard> Railcards { get; set; }

        /// <summary>
        /// Vehicle insurance policies.
        /// </summary>
        public DbSet<VehicleInsurance> VehicleInsurances { get; set; }

        /// <summary>
        /// Vehicle tax.
        /// </summary>
        public DbSet<VehicleTax> VehicleTaxes { get; set; }

        /// <summary>
        /// Vehicle services.
        /// </summary>
        public DbSet<VehicleService> VehicleServices { get; set; }

        /// <summary>
        /// Vehicle finance agreements.
        /// </summary>
        public DbSet<VehicleFinance> VehicleFinances { get; set; }

        /// <summary>
        /// Mortgages.
        /// </summary>
        public DbSet<Mortgage> Mortgages { get; set; }

        /// <summary>
        /// Boiler services.
        /// </summary>
        public DbSet<BoilerService> BoilerServices { get; set; }

        /// <summary>
        /// Energy tariffs.
        /// </summary>
        public DbSet<EnergyTariff> EnergyTariffs { get; set; }

        /// <summary>
        /// Phone contracts.
        /// </summary>
        public DbSet<PhoneContract> PhoneContracts { get; set; }

        /// <summary>
        /// Internet contracts.
        /// </summary>
        public DbSet<InternetContract> InternetContracts { get; set; }

        /// <summary>
        /// Domains.
        /// </summary>
        public DbSet<Domain> Domains { get; set; }

        /// <summary>
        /// SSL certificates.
        /// </summary>
        public DbSet<SslCertificate> SslCertificates { get; set; }

        /// <summary>
        /// Electrical checks.
        /// </summary>
        public DbSet<ElectricalCheck> ElectricalChecks { get; set; }

        /// <summary>
        /// Smoke, carbon monoxide and heat alarms.
        /// </summary>
        public DbSet<Alarm> Alarms { get; set; }

        /// <summary>
        /// API tokens and personal access tokens.
        /// </summary>
        public DbSet<ApiToken> ApiTokens { get; set; }

        /// <summary>
        /// Self Assessment tax returns.
        /// </summary>
        public DbSet<SelfAssessment> SelfAssessments { get; set; }

        /// <summary>
        /// Companies House confirmation statements.
        /// </summary>
        public DbSet<ConfirmationStatement> ConfirmationStatements { get; set; }

        /// <summary>
        /// Companies House annual accounts.
        /// </summary>
        public DbSet<AnnualAccounts> AnnualAccounts { get; set; }

        /// <summary>
        /// ICO data protection fees.
        /// </summary>
        public DbSet<IcoFee> IcoFees { get; set; }

        /// <summary>
        /// Professional indemnity and business insurance policies.
        /// </summary>
        public DbSet<ProfessionalInsurance> ProfessionalInsurances { get; set; }

        /// <summary>
        /// Configures the model, storing every item type in one table.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasDiscriminator<string>("Type");
        }
    }
}