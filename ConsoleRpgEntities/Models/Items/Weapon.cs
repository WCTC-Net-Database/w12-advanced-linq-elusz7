using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpgEntities.Models.Attributes;

namespace ConsoleRpgEntities.Models.Items;

public class Weapon : Item
{
    public int AttackPower { get; set; }

    public override int Use()
    {
        if (Durability > 0)
        {
            Durability--;
            return AttackPower;
        }
        else
        {
            return -1;
        }
    }
    public override string ToString()
    {
        return $"{Name} (Attack: {AttackPower}, Durability: {Durability})";
    }
}
