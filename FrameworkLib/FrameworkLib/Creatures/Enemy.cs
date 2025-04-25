using System.Diagnostics;
using FrameworkLib.Creatures;
using FrameworkLib.Logging;

namespace FrameworkLib
{
    /// <summary>
    /// Represents an enemy creature in the game world.
    /// Inherits from the base Creature class and follows Liskov Substitution Principle and Template Method Pattern.
    /// </summary>
    public class Enemy : Creature
    {
        private Creature? _target;

        /// <summary>
        /// Initializes a new instance of the Enemy class.
        /// </summary>
        /// <param name="name">The name of the enemy.</param>
        /// <param name="hp">The initial health points of the enemy.</param>
        /// <param name="target">An optional target to attack.</param>
        public Enemy(string name, int hp, Creature? target = null) : base(name, hp)
        {
            _target = target;
            Logger.Log($"[Enemy] '{Name}' initialized as Enemy with {Health} HP.");
        }

        /// <summary>
        /// Simulates the enemy roaring to intimidate or warn.
        /// </summary>
        public void Roar()
        {
            Logger.Log($"[Enemy] '{Name}' lets out a terrifying roar!");
        }

        /// <summary>
        /// Implements the Template Method step for the enemy's turn action.
        /// </summary>
        protected override void TakeAction()
        {
            if (_target != null && !_target.IsDead)
            {
                Logger.Log($"[Enemy] '{Name}' snarls and attacks '{_target.Name}'!");
                Attack(_target);
            }
            else
            {
                Logger.Log($"[Enemy] '{Name}' finds no target to attack.");
                Roar();
            }
        }

        /// <summary>
        /// Logs before the creature takes action.
        /// </summary>
        protected override void PreTurn()
        {
            Logger.Log($"[Enemy] '{Name}' is preparing for its turn.");
        }

        /// <summary>
        /// Logs after the creature has taken action.
        /// </summary>
        protected override void PostTurn()
        {
            Logger.Log($"[Enemy] '{Name}' ends its turn.");
        }

        /// <summary>
        /// Calculates the damage the enemy deals when attacking.
        /// </summary>
        /// <returns>The total damage value.</returns>
        public override int Hit()
        {
            int baseDamage = 5;
            if (EquippedWeapon == "Sword") baseDamage += 3;
            if (EquippedWeapon == "Axe") baseDamage += 5;

            Logger.Log($"[Enemy] '{Name}' prepares to hit with {baseDamage} damage");
            return baseDamage;
        }

        /// <summary>
        /// Attacks another creature using strategy or base damage.
        /// </summary>
        /// <param name="target">The target creature.</param>
        public override void Attack(Creature target)
        {
            int damage = AttackStrategy?.ExecuteAttack(this, target) ?? Hit();
            Logger.Log($"[Enemy] '{Name}' attacks '{target.Name}' using strategy for {damage} damage.");
            target.ReceiveHit(damage);
        }
    }
}

