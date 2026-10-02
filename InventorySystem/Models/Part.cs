using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    public class Part
    {
        public int ID {  get; set; }
        public int CatalogID { get; set; }
        public string SoftwareSerialNumber { get; set; } = string.Empty;
        public string HardwareSerialNumber { get; set; } = string.Empty;
        public string OptionalName { get; set; } = string.Empty;
        public string? Note {  get; set; }
        public string? Status {  get; set; }
        public int CurrentLocationID { get; set; }
        public int? CurrentStorageID { get; set; }
        public int? CurrentRackID { get; set; }
        public int? CurrentShelfID { get; set; }
        public int? ParentPartID { get; set; }
        public DateTime LastInventory { get; set; } = DateTime.Now;
        public int? PartTypeID { get; set; }


    }
}
