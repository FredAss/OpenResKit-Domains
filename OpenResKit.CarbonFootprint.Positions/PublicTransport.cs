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
  public class PublicTransport : CarbonFootprintPosition
  {
    public virtual int Kilometrage { get; set; }

    public virtual int m_TransportType { get; set; }

    public virtual TransportType TransportType
    {
      get { return (TransportType) m_TransportType; }
      set
      {
        if ((m_TransportType != (int) value))
        {
          m_TransportType = (int) value;
        }
      }
    }

    public override void Calculate()
    {
      switch (TransportType)
      {
        case TransportType.Metro:
        {
          Calculation = Kilometrage * 72;
          break;
        }
        case TransportType.Linienbus:
        {
          Calculation = Kilometrage * 75;
          break;
        }
        case TransportType.Reisebus:
        {
          Calculation = Kilometrage * 32;
          break;
        }
        case TransportType.Fernzug:
        {
          Calculation = Kilometrage * 52;
          break;
        }
        case TransportType.Regionalzug:
        {
          Calculation = Kilometrage * 95;
          break;
        }
        default:
        {
          Calculation = Kilometrage * 0;
          break;
        }
      }
    }
  }
}