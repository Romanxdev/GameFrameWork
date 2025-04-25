using FrameworkLib.Creatures;

public interface IAttackItem
{
    int Hit { get; }
    int Range { get; }
    int GetDamage(Creature owner);
}