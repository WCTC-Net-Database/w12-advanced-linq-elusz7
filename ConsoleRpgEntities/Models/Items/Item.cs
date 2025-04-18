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

    public int? InventoryId { get; set; }
    public Inventory Inventory { get; set; }

    public abstract int Use();
}
