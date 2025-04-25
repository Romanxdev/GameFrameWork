using FrameworkLib.Creatures;

/// <summary>
/// Strategy interface for custom attack behavior.
/// </summary>
public interface IAttackStrategy
{
    int ExecuteAttack(Creature attacker, Creature target);
}