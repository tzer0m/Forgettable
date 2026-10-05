using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forgettable.Models.Items
{
    /// <summary>
    /// An internal SSL certificate, such as one made with mkcert or a self-signed appliance certificate.
    /// </summary>
    [DisplayName("SSL Certificate")]
    public class SslCertificate : Item
    {
        /// <summary>
        /// The item's category.
        /// </summary>
        public override Category Category => Category.IT;

        /// <summary>
        /// The machine the certificate is installed on.
        /// </summary>
        [Display(Name = "Host")]
        public string Host { get; set; } = string.Empty;

        /// <summary>
        /// Who issued the certificate, e.g. mkcert or self-signed.
        /// </summary>
        [Display(Name = "Issuer")]
        public string Issuer { get; set; } = string.Empty;

        /// <summary>
        /// The date to replace the certificate, 2 weeks before expiry.
        /// </summary>
        public DateOnly ReplaceByDate => ExpiryDate.AddDays(-14);

        /// <summary>
        /// The certificate is due from the replace by date.
        /// </summary>
        public override DateOnly UnbookedDueDate => ReplaceByDate;

        /// <summary>
        /// Why the certificate is due early.
        /// </summary>
        public override string? DueDateReason => "Leave time to generate and install a new certificate before browsers start showing warnings.";
    }
}