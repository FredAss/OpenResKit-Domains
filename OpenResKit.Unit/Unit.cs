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

namespace OpenResKit.Unit
{
  public class Unit
  {
    public virtual int Id { get; set; }

    public virtual double Coefficient { get; set; }

    public virtual string Name { get; set; }

    public virtual string Dimension { get; set; }

    public virtual string Symbol { get; set; }

    public virtual Unit ReferencedUnit { get; set; }

    public bool IsBasicUnit
    {
      get { return ReferencedUnit == null; }
    }

    public virtual Unit BasicUnit
    {
      get { return GetBasicUnit(); }
    }

    public double ToBaseUnit(double valueInThisUnit)
    {
      return IsBasicUnit
        ? valueInThisUnit
        : ReferencedUnit.ToBaseUnit(Coefficient * valueInThisUnit);
    }

    public double FromBaseUnit(double valueInBaseUnit)
    {
      return IsBasicUnit
        ? valueInBaseUnit
        : ReferencedUnit.FromBaseUnit(valueInBaseUnit / Coefficient);
    }

    private Unit GetBasicUnit()
    {
      return IsBasicUnit
        ? this
        : ReferencedUnit.BasicUnit;
    }

    public bool IsConvertibleTo(Unit other)
    {
      return GetBasicUnit() == other.BasicUnit;
    }


    public override string ToString()
    {
      //var isStandard = IsReadonly ? " (standard)" : string.Empty;
      //return string.Format("{0}{1}", Symbol, isStandard);
      return base.ToString();
    }
  }
}