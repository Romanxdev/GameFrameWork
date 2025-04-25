using FrameworkLib.Creatures;
using FrameworkLib.Logging;
using System.Diagnostics;

public class HealEffect : ILootEffect
{
    public int Amount { get; set; }

    public HealEffect(int amount)
    {
        Amount = amount;
    }

    public void ApplyTo(Creature creature)
    {
        creature.Health += Amount;
        Logger.Log($"[Loot] {creature.Name} healed by {Amount} HP");
    }
}

