using ConsoleRpgEntities.Models.Attributes;

namespace ConsoleRpgEntities.Models.Characters.Monsters
{
    public class Goblin : Monster
    {
        public int Sneakiness { get; set; }

        public override void Attack(ITargetable target)
        {
            // Goblin-specific attack logic
            int damage = 8;
            Console.WriteLine($"{Name} sneaks up and attacks {target.Name} for {damage} damage!");

            if (target is Player player)
            {
                player.TakeDamage(damage);
            }
            else
            {
                target.TakeDamage(damage);
            }
        }

        public override string ToString()
        {
            return $"Goblin: {Name}, Health: {Health}";
        }
    }
}
