using System.Collections.Generic;

namespace OpenResKit.Approval.Models
{
    public class AuxillaryCondition
    {
        public virtual int Id { get; set; }
        public virtual string Condition { get; set; }
        public virtual string Reference { get; set; }
        public virtual bool InEffect { get; set; }
        public virtual ICollection<ConditionInspection> ConditionInspections { get; set; } 
    }
}
