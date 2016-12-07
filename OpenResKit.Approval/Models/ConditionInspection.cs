using System;
using System.Collections.Generic;

namespace OpenResKit.Approval.Models
{
    public class ConditionInspection
    {
        
        public virtual int Id { get; set; }

        //[Key, ForeignKey("AuxillaryCondition"), Column(Order = 1)]
        public virtual int AuxillaryConditionId { get; set; }

        //[Key, ForeignKey("Approval_Inspection"), Column(Order = 2)]
        public virtual int InspectionId { get; set; }

        //public virtual AuxillaryCondition AuxillaryCondition { get; set; }

        
        //public virtual Approval_Inspection Approval_Inspection { get; set; }

        public virtual bool Status { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<Approval_Measure> Measures { get; set; } 
        public virtual DateTime EntryDate { get; set; }
    }
}
