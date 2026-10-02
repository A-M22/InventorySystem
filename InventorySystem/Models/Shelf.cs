using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    public class Shelf
    {
        public int ID { get; set; }
        public int RackID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Note {  get; set; } = string.Empty;
        public bool Status { get; set; } = true;

    }
}
