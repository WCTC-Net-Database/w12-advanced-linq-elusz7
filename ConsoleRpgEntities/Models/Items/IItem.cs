using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpgEntities.Models.Items;

public interface IItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Value { get; set; }
    public string Description { get; set; }
}
