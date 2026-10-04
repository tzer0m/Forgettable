using Forgettable.Models;
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
        /// Configures the model, storing every item type in one table.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasDiscriminator<string>("Type");
        }
    }
}