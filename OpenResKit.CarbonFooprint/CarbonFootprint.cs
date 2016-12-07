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

using System.Collections.Generic;
using System.Linq;

namespace OpenResKit.CarbonFootprint
{
  public class CarbonFootprint
  {
    public virtual int Id { get; set; }

    public virtual string Name { get; set; }

    public virtual string Description { get; set; }

    public virtual string SiteLocation { get; set; }

    public virtual int Employees { get; set; }

    public virtual double Calculation { get; set; }

    public virtual ICollection<CarbonFootprintPosition> Positions { get; set; }

    public void Calculate()
    {
      foreach (var position in Positions)
      {
        position.Calculate();
      }
      Calculation = Positions.Sum(position => position.Calculation);
    }

    public override string ToString()
    {
      return Name;
    }
  }
}