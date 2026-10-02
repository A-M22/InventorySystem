using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InventorySystem.Models
{
    public class Storage
    {
        public int ID { get; set; }
        public int LocationID { get; set; }
        public string Name { get; set; } = string.Empty;    
        public string Note { get; set; } = string.Empty;
        public bool Status { get; set; } = true;

    }
}
