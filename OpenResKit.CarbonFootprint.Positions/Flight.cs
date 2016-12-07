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
  public class Flight : CarbonFootprintPosition
  {
    public virtual bool RadiativeForcing { get; set; }

    public virtual int Kilometrage { get; set; }

    public virtual int m_FlightType { get; set; }

    public virtual FlightRange FlightType
    {
      get { return (FlightRange) m_FlightType; }
      set
      {
        if ((m_FlightType != (int) value))
        {
          m_FlightType = (int) value;
        }
      }
    }

    //public int FlightType { get; set; }

    public override void Calculate()
    {
      var intermidiateResult = Utils.CalculateOneFlight(Kilometrage, FlightType, RadiativeForcing);
      Calculation = intermidiateResult;
    }
  }
}