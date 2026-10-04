using System.ComponentModel.DataAnnotations;

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
        /// Who or what the item is for, e.g. a person, vehicle or domain.
        /// </summary>
        [Display(Name = "Subject")]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// The category this item type belongs to.
        /// </summary>
        public abstract Category Category { get; }

        /// <summary>
        /// The date that matters, falling back to the expiry date once booked.
        /// </summary>
        [Display(Name = "Due Date")]
        public DateOnly DueDate => Booked ? ExpiryDate : UnbookedDueDate;

        /// <summary>
        /// The date the item expires.
        /// </summary>
        [Display(Name = "Expiry Date")]
        public DateOnly ExpiryDate { get; set; }

        /// <summary>
        /// Whether the renewal is already booked in, so no reminder is needed.
        /// </summary>
        [Display(Name = "Booked")]
        public bool Booked { get; set; } = false;

        /// <summary>
        /// Whether the item auto-renews.
        /// </summary>
        [Display(Name = "Auto Renew")]
        public bool AutoRenew { get; set; } = false;

        /// <summary>
        /// Whether the item is archived, hiding it from the dashboard and reminders.
        /// </summary>
        public bool Archived { get; set; } = false;

        /// <summary>
        /// The ID of the linked Paperless document, if any.
        /// </summary>
        [Display(Name = "Paperless Document", AutoGenerateField = false)]
        public int? PaperlessDocumentId { get; set; }

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