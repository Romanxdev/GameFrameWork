using FrameworkLib.Items;
using System;
using System.Collections.Generic;

namespace FrameworkLib
{
    /// <summary>
    /// Represents an object in the game world that can contain loot and effects.
    /// </summary>
    public class WorldObject
    {
        /// <summary>
        /// The name of the object.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Indicates whether the object can be looted.
        /// </summary>
        public bool LootAbble { get; set; }

        /// <summary>
        /// Indicates whether the object should be removed from the world after looting.
        /// </summary>
        public bool Removeable { get; set; }

        /// <summary>
        /// The X-coordinate of the object in the world.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The Y-coordinate of the object in the world.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// List of loot effects (e.g., healing, buffs).
        /// </summary>
        public List<ILootEffect> Effects { get; set; } = new();

        /// <summary>
        /// Optional: a weapon that can be looted.
        /// </summary>
        public IAttackItem? LootedAttackItem { get; set; }

        /// <summary>
        /// Optional: a shield or defensive item that can be looted.
        /// </summary>
        public DefenceItem? LootedDefenceItem { get; set; }
    }
}
