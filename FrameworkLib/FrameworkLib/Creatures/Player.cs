using System.Diagnostics;
using FrameworkLib.Creatures;
using FrameworkLib.Logging;

namespace FrameworkLib
{
    /// <summary>
    /// Represents a player-controlled creature with special abilities.
    /// Inherits from the base Creature class and follows Liskov Substitution Principle and Template Method Pattern.
    /// </summary>
    public class Player : Creature
    {
        private Creature? _target;

        /// <summary>
        /// Initializes a new instance of the Player class.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <param name="hp">The initial health points of the player.</param>
        /// <param name="target">An optional target to attack.</param>
        public Player(string name, int hp, Creature? target = null) : base(name, hp)
        {
            _target = target;
            Logger.Log($"[Player] '{Name}' initialized as Player with {Health} HP.");
        }

        /// <summary>
        /// Simulates the player casting a magical ability.
        /// </summary>
        public void UseMagic()
        {
            Logger.Log($"[Player] '{Name}' casts a powerful spell!");
        }

        /// <summary>
        /// Implements the Template Method step for the player's turn action.
        /// </summary>
        protected override void TakeAction()
        {
            if (_target != null && !_target.IsDead)
            {
                Logger.Log($"[Player] '{Name}' chooses to attack '{_target.Name}'!");
                Attack(_target);
            }
            else
            {
                Logger.Log($"[Player] '{Name}' has no target to attack.");
            }
        }

        /// <summary>
        /// Logs before the creature takes action.
        /// </summary>
        protected override void PreTurn()
        {
            Logger.Log($"[Player] '{Name}' is preparing for its turn.");
        }

        /// <summary>
        /// Logs after the creature has taken action.
        /// </summary>
        protected override void PostTurn()
        {
            Logger.Log($"[Player] '{Name}' ends its turn.");
        }

        /// <summary>
        /// Calculates the damage the player deals when attacking.
        /// </summary>
        /// <returns>The total damage value.</returns>
        public override int Hit()
        {
            int baseDamage = 5;
            if (EquippedWeapon == "Sword") baseDamage += 3;
            if (EquippedWeapon == "Axe") baseDamage += 5;

            Logger.Log($"[Player] '{Name}' prepares to hit with {baseDamage} damage");
            return baseDamage;
        }

        /// <summary>
        /// Attacks another creature using strategy or base damage.
        /// </summary>
        /// <param name="target">The target creature.</param>
        public override void Attack(Creature target)
        {
            int damage = AttackStrategy?.ExecuteAttack(this, target) ?? Hit();
            Logger.Log($"[Player] '{Name}' attacks '{target.Name}' using strategy for {damage} damage.");
            target.ReceiveHit(damage);
        }
    }
}

