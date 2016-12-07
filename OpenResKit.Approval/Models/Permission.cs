using System;
using System.Collections.Generic;
using OpenResKit.Organisation;

namespace OpenResKit.Approval.Models
{
    public class Permission
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool InEffect { get; set; }
        public virtual int PermissionKind { get; set; }
        public virtual string FileNumber { get; set; }
        public virtual DateTime DateOfApplication { get; set; }
        public virtual DateTime StartOfPermission { get; set; }
        public virtual DateTime EndOfPermission { get; set; }
        public virtual ICollection<Document> AttachedDocuments { get; set; } 
        public virtual ICollection<Plant> Plants { get; set; }
        public virtual ICollection<AuxillaryCondition> AuxillaryConditions { get; set; } 

        internal KindOfPermission KindEnum
        {
            get { return (KindOfPermission) PermissionKind; }
            set
            {
                if (PermissionKind != (int) value)
                {
                    PermissionKind = (int)value;
                }
            }
        }
    }
}
