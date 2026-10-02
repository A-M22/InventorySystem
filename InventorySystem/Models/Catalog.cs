namespace InventorySystem.Models
{
    public class Catalog
    {
        public int ID {  get; set; }
        public int ItemCodeID { get; set; }
        public int ItemTypeID { get; set; }
        public string PartNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Note {  get; set; } = string.Empty;
    }
}
