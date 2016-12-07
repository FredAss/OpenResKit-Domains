using System.Collections.Generic;
using OpenResKit.Organisation;

namespace OpenResKit.Approval.Models
{
    public class Plant
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Number { get; set; }
        public virtual string Position { get; set; }
        public virtual PlantImageSource PlantImageSource { get; set; }
        public virtual ICollection<Document> AttachedDocuments { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<Substance> Substances { get; set; } 
    }
}
