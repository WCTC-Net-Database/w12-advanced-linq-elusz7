using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpgEntities.Models.Characters;

namespace ConsoleRpgEntities.Models.Items;

public abstract class Item : IItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Value { get; set; }
    public string Description { get; set; }
    public int Durability { get; set; }

    public string ItemType { get; set; }

    public int PlayerId { get; set; }

    public Player Player { get; set; } = new Player();

    public abstract int Use();
}
