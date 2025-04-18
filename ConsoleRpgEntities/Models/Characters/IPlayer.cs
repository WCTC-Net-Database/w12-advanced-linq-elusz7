using System.ComponentModel.DataAnnotations.Schema;
using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Items;

namespace ConsoleRpgEntities.Models.Characters;

public interface IPlayer
{
    int Id { get; set; }
    string Name { get; set; }

    ICollection<Ability> Abilities { get; set; }

    Inventory Inventory { get; set; }

    void Attack(ITargetable target);
    void UseAbility(IAbility ability, ITargetable target);


}
