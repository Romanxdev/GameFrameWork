using System;
using System.Diagnostics;
using System.Linq; // Tilføjet for LINQ
using System.Collections.Generic;
using FrameworkLib.Logging;
using FrameworkLib.Items; // Tilføjet for DefenceItem

namespace FrameworkLib.Creatures
{
    /// <summary>
    /// Represents a creature in the game world with health, weapons, shields, and abilities.
    /// </summary>
    public abstract class Creature
    {
        /// <summary>
        /// The name of the creature.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The current health of the creature.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Indicates whether the creature is dead.
        /// </summary>
        public bool IsDead { get; set; }

        public List<IAttackItem> AttackItems { get; } = new();

        /// <summary>
        /// The currently equipped weapon.
        /// </summary>
        public string? EquippedWeapon { get; set; }

        /// <summary>
        /// The currently equipped shield item.
        /// </summary>
        public DefenceItem? EquippedShield { get; set; }

        /// <summary>
        /// The creature's magical ability.
        /// </summary>
        public string? MagicAbility { get; set; }

        /// <summary>
        /// The X-coordinate of the creature in the world.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The Y-coordinate of the creature in the world.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Initializes a new creature with a name, hit points, and optional position.
        /// </summary>
        /// <param name="name">The name of the creature.</param>
        /// <param name="hitPoint">The starting health of the creature.</param>
        /// <param name="x">Initial X position.</param>
        /// <param name="y">Initial Y position.</param>
        public Creature(string name, int hitPoint, int x = 0, int y = 0)
        {
            Name = name;
            Health = hitPoint;
            IsDead = false;
            X = x;
            Y = y;
        }

        public IAttackStrategy? AttackStrategy { get; set; }

        /// <summary>
        /// Event that is triggered when the creature receives damage.
        /// Implements the Observer design pattern.
        /// </summary>
        public event Action<Creature, int>? OnHit;


        /// <summary>
        /// Calculates the damage this creature deals when attacking.
        /// </summary>
        /// <returns>The total damage value.</returns>
        public virtual int Hit()
        {
            int baseDamage = 5;
            if (EquippedWeapon == "Sword") baseDamage += 3;
            if (EquippedWeapon == "Axe") baseDamage += 5;

            Logger.Log($"[Creature] '{Name}' prepares to hit with {baseDamage} damage");
            return baseDamage;
        }

        /// <summary>
        /// Reduces the creature's health based on incoming damage and equipped shield.
        /// </summary>
        /// <param name="hit">The amount of incoming damage.</param>
        public void ReceiveHit(int hit)
        {
            int originalHit = hit;

            if (EquippedShield != null)
            {
                hit -= EquippedShield.GetDamageReduction();
            }

            if (hit < 0) hit = 0;

            Health -= hit;
            Logger.Log($"[{GetType().Name}] '{Name}' received {hit} damage. Health now: {Health}");

            OnHit?.Invoke(this, hit);

            if (Health <= 0)
            {
                Health = 0;
                IsDead = true;
                Logger.Log($"[Creature] '{Name}' has died.");
            }
        }

        /// <summary>
        /// Attacks another creature using the assigned strategy (if any).
        /// Falls back to default Hit() if no strategy is set.
        /// </summary>
        /// <param name="target">The creature to attack.</param>
        public virtual void Attack(Creature target)
        {
            int damage;

            if (AttackStrategy != null)
            {
                damage = AttackStrategy.ExecuteAttack(this, target);
                Logger.Log($"[Creature] '{Name}' attacks '{target.Name}' using strategy for {damage} damage.");
            }
            else
            {
                damage = Hit();
                Logger.Log($"[Creature] '{Name}' attacks '{target.Name}' for {damage} damage.");
            }

            target.ReceiveHit(damage);
        }

        /// <summary>
        /// Attempts to loot a world object and applies its loot effects.
        /// </summary>
        /// <param name="obj">The object to loot.</param>
        public void Loot(WorldObject obj)
        {
            if (!obj.LootAbble)
            {
                Logger.Log($"[Creature] '{Name}' tried to loot '{obj.Name}' but couldn't.");
                return;
            }

            var healing = obj.Effects.Where(e => e is HealEffect).ToList();
            if (healing.Any())
            {
                Logger.Log($"[Creature] '{Name}' found healing in '{obj.Name}'!");
            }

            obj.Effects
               .ToList()
               .ForEach(effect => effect.ApplyTo(this));

            Logger.Log($"[Creature] '{Name}' looted '{obj.Name}'.");
        }

        /// <summary>
        /// Template Method – defines a standard turn flow for all creatures.
        /// </summary>
        public void PerformTurn()
        {
            PreTurn();
            TakeAction();
            PostTurn();
        }

        /// <summary>
        /// Logic to run before the creature takes action. Can be overridden.
        /// </summary>
        protected virtual void PreTurn()
        {
            Logger.Log($"[Creature] '{Name}' is preparing for its turn.");
        }

        /// <summary>
        /// The main action of the creature. Must be implemented by subclasses.
        /// </summary>
        protected abstract void TakeAction();

        /// <summary>
        /// Logic to run after the creature takes action. Can be overridden.
        /// </summary>
        protected virtual void PostTurn()
        {
            Logger.Log($"[Creature] '{Name}' ends its turn.");
        }
    }
}

