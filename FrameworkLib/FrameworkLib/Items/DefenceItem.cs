using System;

namespace FrameworkLib.Items
{
    /// <summary>
    /// Represents a defensive item such as a shield 
    /// that can reduce incoming damage.
    /// </summary>
    public class DefenceItem
    {
        /// <summary>
        /// The name of the defence item.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The number of hit points this item can reduce when damage is received.
        /// </summary>
        public int ReduceHitPoint { get; set; }

        /// <summary>
        /// Returns how many hit points this item reduces.
        /// </summary>
        public int GetDamageReduction()
        {
            return ReduceHitPoint;
        }
    }
}
