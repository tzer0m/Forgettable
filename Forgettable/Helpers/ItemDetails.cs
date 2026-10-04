using Forgettable.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Forgettable.Helpers
{
    /// <summary>
    /// Builds an item's details from its properties marked with a display name.
    /// </summary>
    public static class ItemDetails
    {
        /// <summary>
        /// Returns the item's details in display order, shared fields first.
        /// </summary>
        /// <param name="item">The item.</param>
        public static List<ItemDetail> Get(Item item)
        {
            List<ItemDetail> details = [new ItemDetail { Label = "Type", Text = ItemTypes.GetDisplayName(item.GetType()) }];
            IEnumerable<PropertyInfo> properties = item.GetType().GetProperties().OrderBy(x => Depth(x.DeclaringType!)).ThenBy(x => x.MetadataToken);
            foreach (PropertyInfo property in properties)
            {
                DisplayAttribute? display = property.GetCustomAttribute<DisplayAttribute>();
                if (display == null || display.GetAutoGenerateField() == false)
                {
                    continue;
                }
                object? value = property.GetValue(item);
                if (value == null || value is string text && string.IsNullOrWhiteSpace(text))
                {
                    continue;
                }
                bool isExpiry = property.Name == nameof(Item.ExpiryDate);
                if (isExpiry && item.ExpiryDate == item.DueDate)
                {
                    continue;
                }
                details.Add(new ItemDetail { Label = display.GetName() ?? property.Name, Text = Format(property, value), Value = value, Hint = isExpiry ? item.DueDateReason : null });
            }
            return details;
        }

        /// <summary>
        /// Formats a value as text, using the property's display format if it has one.
        /// </summary>
        /// <param name="property">The property the value came from.</param>
        /// <param name="value">The value.</param>
        private static string Format(PropertyInfo property, object value)
        {
            string? format = property.GetCustomAttribute<DisplayFormatAttribute>()?.DataFormatString;
            if (format != null)
            {
                return string.Format(format, value);
            }
            return value switch { DateOnly date => date.ToString("dd MMM yyyy"), bool flag => flag ? "Yes" : "No", _ => value.ToString() ?? string.Empty };
        }

        /// <summary>
        /// Returns how many classes a type inherits from, so base class properties sort first.
        /// </summary>
        /// <param name="type">The type.</param>
        private static int Depth(Type type)
        {
            int depth = 0;
            for (Type? current = type.BaseType; current != null; current = current.BaseType)
            {
                depth++;
            }
            return depth;
        }
    }
}