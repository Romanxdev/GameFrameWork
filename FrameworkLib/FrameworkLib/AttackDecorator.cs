 using FrameworkLib.Creatures;

namespace FrameworkLib.Items
{
    public class AttackDecorator : IAttackItem
    {
        private readonly IAttackItem _baseItem;

        public AttackDecorator(IAttackItem baseItem)
        {
            _baseItem = baseItem;
        }

        public int Hit => _baseItem.Hit + 5; 
        public int Range => _baseItem.Range;

        public int GetDamage(Creature owner)
        {
            return _baseItem.GetDamage(owner) + 5; 
        }
    }
}