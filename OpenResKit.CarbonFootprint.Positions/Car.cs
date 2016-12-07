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

using System.ComponentModel.Composition;

namespace OpenResKit.CarbonFootprint.Positions
{
  [Export(typeof (CarbonFootprintPosition))]
  public class Car : CarbonFootprintPosition
  {
    public virtual double CarbonProduction { get; set; }
    public virtual double Consumption { get; set; }

    public virtual Fuel Fuel
    {
      get { return (Fuel) m_Fuel; }
      set
      {
        if ((m_Fuel != (int) value))
        {
          m_Fuel = (int) value;
        }
      }
    }

    public virtual int Kilometrage { get; set; }

    public virtual int m_Fuel { get; set; }

    public override void Calculate()
    {
      Calculation = CalculateOneCar(Kilometrage, Consumption, Fuel, CarbonProduction);
    }

    protected static double CalculateOneCar(int kilometrage, double consumption, Fuel fuel, double carbonProduction)
    {
      var intermidiateResult = (kilometrage / 100) * consumption;
      switch (fuel)
      {
        case Fuel.Diesel:
        {
          intermidiateResult *= 470;
          //CarbonProduction = 26.2 * Consumption;
          break;
        }
        case Fuel.Benzin:
        {
          //CarbonProduction = 23.2 * Consumption;
          intermidiateResult *= 780;
          break;
        }
      }
      intermidiateResult += carbonProduction * kilometrage;
      return intermidiateResult;
    }
  }
}