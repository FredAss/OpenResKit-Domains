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
  public class EnergyConsumption : CarbonFootprintPosition
  {
    public virtual double Consumption { get; set; }

    public virtual int m_EnergySource { get; set; }

    public virtual EnergySource EnergySource
    {
      get { return (EnergySource) m_EnergySource; }
      set
      {
        if ((m_EnergySource != (int) value))
        {
          m_EnergySource = (int) value;
        }
      }
    }

    public virtual double CarbonProduction { get; set; }

    public override void Calculate()
    {
      //result += Nuclear * 32;

      switch (EnergySource)
      {
        case EnergySource.Ecostrom:
        {
          Calculation = Consumption * 40;
          break;
        }
        case EnergySource.Strommix:
        {
          Calculation = Consumption * 600;
          break;
        }
        case EnergySource.Erdgas:
        {
          Calculation = Consumption * 428;
          break;
        }
        case EnergySource.Heizoel:
        {
          Calculation = Consumption * 897;
          break;
        }
        case EnergySource.Steinkohle:
        {
          Calculation = Consumption * 949;
          break;
        }
        case EnergySource.Braunkohle:
        {
          Calculation = Consumption * 1153;
          break;
        }
        case EnergySource.Benutzerspezifisch:
        {
          Calculation = Consumption * CarbonProduction;
          break;
        }
        default:
        {
          Calculation = Consumption * 0;
          break;
        }
      }
    }
  }
}