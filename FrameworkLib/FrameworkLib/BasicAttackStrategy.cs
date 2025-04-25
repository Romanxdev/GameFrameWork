using FrameworkLib.Creatures;

/// <summary>
/// Basic attack using the default Hit() method.
/// </summary>
public class BasicAttackStrategy : IAttackStrategy
{
    public int ExecuteAttack(Creature attacker, Creature target)
    {
        return attacker.Hit();
    }
}