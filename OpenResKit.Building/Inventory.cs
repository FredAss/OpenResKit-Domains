namespace OpenResKit.Building
{
    public class Inventory
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string InventoryId { get; set; }
        public virtual string Producer { get; set; }
        public virtual string YearOfManufacture { get; set; }

        public virtual BuildingRoom Room { get; set; }
        public virtual InventoryType InventoryType { get; set; }
    }
}