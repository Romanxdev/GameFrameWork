using FrameworkLib.Creatures;
using System.Collections.Generic;
using System.Linq;

namespace FrameworkLib.Items
{
    /// <summary>
    /// Composite class that can hold multiple attack items
    /// and treat them as a single IAttackItem.
    /// Implements the Composite Pattern.
    /// </summary>
    public class AttackComposite : IAttackItem
    {
        private readonly List<IAttackItem> _items = new();

        /// <summary>
        /// Adds an attack item to the composite.
        /// </summary>
        /// <param name="item">The attack item to add.</param>
        public void Add(IAttackItem item)
        {
            _items.Add(item);
        }

        /// <summary>
        /// Total hit value of all contained attack items.
        /// </summary>
        public int Hit => _items.Sum(i => i.Hit);

        /// <summary>
        /// Returns the maximum range among all contained attack items.
        /// If the list is empty, returns 0.
        /// </summary>
        public int Range => _items.Any() ? _items.Max(i => i.Range) : 0;

        /// <summary>
        /// Returns the combined damage of all attack items
        /// when used by the given creature.
        /// </summary>
        /// <param name="owner">The creature using the attack.</param>
        /// <returns>Total damage from all items.</returns>
        public int GetDamage(Creature owner)
        {
            return _items.Sum(i => i.GetDamage(owner));
        }
    }
}
