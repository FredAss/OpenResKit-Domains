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

namespace OpenResKit.Noise
{
  public class MeasuringPoint
  {
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    public virtual string Barcode { get; set; }
    public virtual NoiseMapPosition Position { get; set; }
    public virtual string Notes { get; set; }
    public virtual float GreenValue { get; set; }
    public virtual float YellowValue { get; set; }
    public virtual float RedValue { get; set; }
    public virtual bool IsArchived { get; set; }
  }
}