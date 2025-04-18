using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpgEntities.Models.Characters;

namespace ConsoleRpgEntities.Models.Items;

public class Inventory
{
    public int Id { get; set; }
    public int Gold { get; set; }
    public int Capacity { get; set; }
    public int PlayerId { get; set; }
    public virtual Player Player { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
