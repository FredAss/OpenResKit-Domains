using System.Collections.Generic;

namespace OpenResKit.Building
{
    public class InventoryType
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; } 
    }
}