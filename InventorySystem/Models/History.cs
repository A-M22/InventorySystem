using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    internal class History
    {
        public int ID { get; set; }
        public int PartID { get; set; }
        public int? FromLocationID { get; set; }
        public int? ToLocationID { get; set; }
        public int? FromStorageID { get; set; }
        public int ?ToStorageID { get; set; }
        public int? FromRackID { get; set; }
        public int? ToRackID { get; set; }
        public int? FromShelfID { get; set; }
        public int? ToShelfID { get;set; }
        public int ActionID { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public string? FromStatus { get; set; }
        public string? ToStatus { get; set; }

    }
}
