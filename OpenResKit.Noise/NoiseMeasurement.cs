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

namespace OpenResKit.Noise
{
  public class NoiseMeasurement
  {
    public virtual int Id { get; set; }
    public virtual DateTime MeasurementDate { get; set; }
    public virtual float MinValue { get; set; }
    public virtual float MaxValue { get; set; }
    public virtual float AverageValue { get; set; }
    public virtual MeasuringMethod Method { get; set; }
    public virtual string Employee { get; set; }
    public virtual string Comment { get; set; }
    public virtual MeasuringPoint MeasuringPoint { get; set; }
  }
}