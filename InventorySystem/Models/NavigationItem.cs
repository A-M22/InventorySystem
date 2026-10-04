using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    public class NavigationItem
    {
        public string Name { get; set; } = string.Empty;
        public Action Navigate { get; set; } = null!;

    }
}
