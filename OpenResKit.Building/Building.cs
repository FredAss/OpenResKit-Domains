using System.Collections.Generic;

namespace OpenResKit.Building
{
    public class Building
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<BuildingRoom> Rooms { get; set; }
    }
}