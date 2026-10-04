using System.ComponentModel;
using System.Reflection;

namespace Forgettable.Models
{
    /// <summary>
    /// Discovers the available item types.
    /// </summary>
    public static class ItemTypes
    {
        /// <summary>
        /// Every concrete item type, keyed by class name.
        /// </summary>
        public static Dictionary<string, Type> All { get; } = typeof(Item).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Item)) && !x.IsAbstract).OrderBy(GetDisplayName).ToDictionary(x => x.Name, x => x, StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Returns the friendly name for an item type.
        /// </summary>
        /// <param name="type">The item type.</param>
        public static string GetDisplayName(Type type)
        {
            return type.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? type.Name;
        }

        /// <summary>
        /// Returns the category for an item type.
        /// </summary>
        /// <param name="type">The item type.</param>
        public static Category GetCategory(Type type)
        {
            return ((Item)Activator.CreateInstance(type)!).Category;
        }
    }
}