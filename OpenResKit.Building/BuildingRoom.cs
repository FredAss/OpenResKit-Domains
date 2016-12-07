using System.Collections.Generic;

namespace OpenResKit.Building
{
    public class BuildingRoom
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual double Area { get; set; }
        public virtual double Height { get; set; }

        public Building Building { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}