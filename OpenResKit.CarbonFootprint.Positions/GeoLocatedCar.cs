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
  public class GeoLocatedCar : FullyQualifiedCar
  {
    public virtual string StartName { get; set; }
    public virtual double StartLatitude { get; set; }
    public virtual double StartLongitude { get; set; }
    public virtual string DestinationName { get; set; }
    public virtual double DestinationLatitude { get; set; }
    public virtual double DestinationLongitude { get; set; }
  }
}