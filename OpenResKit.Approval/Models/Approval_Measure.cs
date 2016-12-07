using System;
using System.Collections.Generic;
using OpenResKit.Organisation;

namespace OpenResKit.Approval.Models
{
    public class Approval_Measure : Measure.Measure
    {
       
        public virtual int Progress { get; set; }
      

        internal Progress ProgressEnum
        {
            get { return (Progress) Progress; }
            set
            {
                if (Progress != (int) value)
                {
                    Progress = (int)value;
                }
            }
        }

       
    }
}
