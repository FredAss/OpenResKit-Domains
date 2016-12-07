#region License

// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at
//  
// http://www.apache.org/licenses/LICENSE-2.0.html
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  
// Copyright (c) 2013, HTW Berlin

#endregion

using System;
using System.Collections.Generic;
using OpenResKit.Organisation;

namespace OpenResKit.Discard
{
  public class Inspection
  {
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    public virtual DateTime ProductionDate { get; set; }
    public virtual DateTime InspectionDate { get; set; }
    public virtual int ProductionShift { get; set; }
    public virtual int InspectionShift { get; set; }

    internal Shift InspectionShiftEnum
    {
      get { return (Shift) InspectionShift; }
      set
      {
        if ((InspectionShift != (int) value))
        {
          InspectionShift = (int) value;
        }
      }
    }

    internal Shift ProductionShiftEnum
    {
      get { return (Shift) ProductionShift; }
      set
      {
        if ((ProductionShift != (int) value))
        {
          ProductionShift = (int) value;
        }
      }
    }

    public virtual int InspectionType { get; set; }

    internal InspectionType InspectionTypeEnum
    {
      get { return (InspectionType) InspectionType; }
      set
      {
        if ((InspectionType != (int) value))
        {
          InspectionType = (int) value;
        }
      }
    }

    public virtual int SampleSize { get; set; }
    public virtual string Unit { get; set; }
    public virtual int TotalAmount { get; set; }
    public virtual string Description { get; set; }
    public virtual ResponsibleSubject ResponsibleSubject { get; set; }
    public virtual ProductionItem ProductionItem { get; set; }
    public virtual ICollection<DiscardItem> DiscardItems { get; set; }
    public virtual bool Finished { get; set; }
  }
}