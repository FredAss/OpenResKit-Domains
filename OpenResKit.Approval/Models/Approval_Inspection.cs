using System.Collections.Generic;
using OpenResKit.Organisation;

namespace OpenResKit.Approval.Models
{
    public class Approval_Inspection : ScheduledTask
    {
        public virtual ICollection<ConditionInspection> ConditionInspections { get; set; } 
    }
}
