using FrameworkLib.Creatures;


namespace FrameworkLib.Items
{
    /// <summary>
    /// Represents an attack item such as a weapon or magical ability,
    /// which can deal damage to enemies.
    /// </summary>
    public class AttackItem : IAttackItem
    {
        /// <summary>
        /// The name of the attack item.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// A short description of the item.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The amount of damage this item can deal.
        /// </summary>
        public int Hit { get; set; }

        /// <summary>
        /// The range of the item — how far it can reach.
        /// </summary>
        public int Range { get; set; }

        /// <summary>
        /// Returns the damage this attack item deals (can be decorated).
        /// </summary>
        public int GetDamage(Creature owner)
        {
            return Hit;
        }
    }
}