using System.ComponentModel.DataAnnotations.Schema;
using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Characters.Monsters;
using ConsoleRpgEntities.Models.Items;

namespace ConsoleRpgEntities.Models.Characters
{
    public class Player : ITargetable, IPlayer
    {
        public int Experience { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public virtual ICollection<Ability> Abilities { get; set; } = new List<Ability>();
        public virtual ICollection<Item> Inventory { get; set; } = new List<Item>();
        public void Attack(ITargetable target)
        {
            if (CanAttack(target))
            {
                Weapon? weapon = SelectAttackWeapon();

                if (weapon == null)
                {
                    Console.WriteLine("No weapon available. Attack failed.");
                    return;
                }
                else
                {
                    int damage = weapon.Use();

                    if (damage > 0)
                    {
                        OutputDamage(target.Name, weapon.Name, damage);

                        if (target is Monster monster)
                        {
                            monster.TakeDamage(damage);
                        }
                        else
                        {
                            target.TakeDamage(damage);
                        }

                        if (weapon.Durability == 0)
                        {
                            Console.WriteLine($"{weapon.Name} is broken and cannot be used anymore!");
                        }
                        
                        GainExperience(target);
                    }
                    else
                    {
                        ColorDisplay(weapon.Name, ConsoleColor.Blue);
                        Console.WriteLine(" is broken and cannot be used!");
                    }
                }
            }
        }
        public void UseAbility(IAbility ability, ITargetable target)
        {
            if (CanAttack(target))
            {
                if (Abilities.Contains(ability))
                {
                    ability.Activate(this, target);
                    GainExperience(target);
                }
                else
                {
                    Console.WriteLine($"{Name} does not have the ability {ability.Name}!");
                }
            }
        }
        private static bool CanAttack(ITargetable target)
        {
            if (target is Monster monster)
                if (monster.Health <= 0)
                {
                    Console.WriteLine($"{target.Name} has already been defeated!");
                    return false;
                }
            return true;
        }
        public void TakeDamage(int damage)
        {
            Armor? armor = ReduceDamage();

            if (armor != null)
            {
                int absorbed = armor.Use();
                
                damage -= absorbed;

                Console.WriteLine($"{armor.Name} absorbs {absorbed} damage!");

                if (armor.Durability <= 0)
                {
                    Console.WriteLine($"{armor.Name} is broken and cannot be used anymore!");
                }
            }

            if (damage <= 0)
            {
                Console.WriteLine($"{Name} takes no damage!");
            }
            else
            {
                Health -= damage;
                Console.WriteLine($"{Name} takes {damage} damage!");
            }
        }
        private Weapon? SelectAttackWeapon()
        {
            var validWeapons = Inventory
                .Select((item, index) => new { Item = item, Index = index })
                .Where(entry => entry.Item is Weapon weapon && weapon.Durability > 0)
                .ToList();

            if (!validWeapons.Any())
            {
                return null;
            }

            for (int i = 0; i < validWeapons.Count; i++)
            {
                var weapon = validWeapons[i].Item;
                Console.WriteLine($"{i + 1}. {weapon.Name} (Durability: {weapon.Durability})");
            }

            while (true)
            {
                Console.WriteLine("Which weapon do you want to use? (Enter the number)");
                bool isInt = int.TryParse(Console.ReadLine(), out var weaponIndex);

                if (weaponIndex < 1 || weaponIndex > validWeapons.Count || !isInt)
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
                else
                {
                    return (Weapon)validWeapons[weaponIndex - 1].Item;
                }
            }
        }
        private Armor? ReduceDamage()
        {
            Armor? activeArmor = null;

            foreach (Item item in Inventory)
            {
                if (item is Armor armor && armor.Durability > 0)
                {
                    if (activeArmor == null || armor.DefensePower > activeArmor.DefensePower)
                    {
                        activeArmor = armor;
                    }
                }
            }

            return activeArmor;
        }
        private void OutputDamage(string targetName, string weaponName, int damage)
        {
            ColorDisplay(Name, ConsoleColor.Green);
            Console.Write(" attacks ");

            ColorDisplay(targetName, ConsoleColor.Yellow);
            Console.Write(" with ");

            ColorDisplay(weaponName, ConsoleColor.Blue);
            Console.Write(" for ");

            ColorDisplay(damage.ToString(), ConsoleColor.Red);
            Console.WriteLine(" damage!");
        }
        private void GainExperience(ITargetable target)
        {
            if ((target is Monster monster) && (monster.Health <= 0))
            {
                Experience += monster.AggressionLevel;
                Console.WriteLine($"{Name} gained {monster.AggressionLevel} experience!");
            }
        }
        private static void ColorDisplay(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
        public override string ToString()
        {
            return $"{Name} (Health: {Health}, Experience: {Experience})";
        }

    }
}
