using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forgettable.Models
{
    /// <summary>
    /// Base class for every tracked item.
    /// </summary>
    public abstract class Item
    {
        /// <summary>
        /// The primary key.
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// The item's name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The date the item expires.
        /// </summary>
        [Display(Name = "Expiry Date")]
        public DateOnly ExpiryDate { get; set; }

        /// <summary>
        /// Whether the renewal is already booked in, so no reminder is needed.
        /// </summary>
        public bool Booked { get; set; } = false;

        /// <summary>
        /// Whether the item auto-renews.
        /// </summary>
        [Display(Name = "Auto Renew")]
        public bool AutoRenew { get; set; } = false;

        /// <summary>
        /// The IDs of linked Paperless documents.
        /// </summary>
        public List<int> PaperlessDocumentIds { get; set; } = [];

        /// <summary>
        /// The linked Paperless document IDs as a comma-separated list, for the form.
        /// </summary>
        [NotMapped]
        [Display(Name = "Paperless Documents")]
        public string? PaperlessDocuments
        {
            get => string.Join(",", PaperlessDocumentIds);
            set => PaperlessDocumentIds = [.. (value ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).Distinct()];
        }

        /// <summary>
        /// The date that matters, falling back to the expiry date once booked.
        /// </summary>
        public DateOnly DueDate => Booked ? ExpiryDate : UnbookedDueDate;

        /// <summary>
        /// The date that matters for this item type before it's booked, defaulting to the expiry date.
        /// </summary>
        public virtual DateOnly UnbookedDueDate => ExpiryDate;

        /// <summary>
        /// Why the due date differs from the expiry date, if it does.
        /// </summary>
        public virtual string? DueDateReason => null;
    }
}